        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IJSRuntime JsRuntime { get; set; }
        public async Task NavigateToUrlAsync(string url, bool openInNewTab)
        {
            if (openInNewTab)
            {
                await JsRuntime.InvokeAsync<object>("open", url, "_blank");
            }
            else
            {
                NavigationManager.NavigateTo(url);
            }
        }
