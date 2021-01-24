    @page "/"
    
    @inject IJSRuntime jsRuntime
    
    <div>
        Select a text file:
        <input type="file" id="fileInput" @onchange="@ReadFileContent" />
    </div>
    <pre>
        @fileContent
    </pre>
    
    Welcome to your new app.
    
    @code{
    
        private string fileContent { get; set; }
    
        public static object CreateDotNetObjectRefSyncObj = new object();
    
        public async Task ReadFileContent(UIChangeEventArgs ea)
        {
            // Fire & Forget: ConfigureAwait(false) is telling "I'm not expecting this call to return a thing"
            await jsRuntime.InvokeAsync<object>("readFileProxy", CreateDotNetObjectRef(this), "ReadFileCallback", ea.Value.ToString()).ConfigureAwait(false);
        }
    
    
        [JSInvokable] // This is required in order to JS be able to execute it
        public void ReadFileCallback(string response)
        {
            fileContent = response?.ToString();
            StateHasChanged();
        }
    
        // Hack to fix https://github.com/aspnet/AspNetCore/issues/11159    
        protected DotNetObjectRef<T> CreateDotNetObjectRef<T>(T value) where T : class
        {
            lock (CreateDotNetObjectRefSyncObj)
            {
                JSRuntime.SetCurrentJSRuntime(jsRuntime);
                return DotNetObjectRef.Create(value);
            }
        }
    
    }
