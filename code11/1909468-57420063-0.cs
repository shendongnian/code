     bool firstRender = true;
    
        protected async override Task OnAfterRenderAsync()
        {
            if (firstRender)
            {
    
                await jsRuntime.InvokeAsync<string>("initializeCarousel");
                firstRender = false;
            }
        }
