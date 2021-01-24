    @code
    {
        protected bool Rendered = false;
        protected async override Task OnAfterRenderAsync()
        {
            if (!Rendered) 
            {
                Rendered = true;
                await OnAfterFirstRenderAsync();
            }            
        }
        protected async Task OnAfterFirstRenderAsync()
        {
            data = await TaskService.GetDataAsync();
        }
    }
