    @code{
        protected override void OnInitialized()
        {
             _YourService.OnChange += OnMyChangeHandler;
        }
        public void Dispose()
        {
	         _YourService.OnChange -= OnMyChangeHandler;
        }
        private async void OnMyChangeHandler(object sender, EventArgs e)
        {
    	    DoStuff();
    	    // InvokeAsync is inherited, it syncs the call back to the render thread
            await InvokeAsync(() => StateHasChanged());
        }
    }
