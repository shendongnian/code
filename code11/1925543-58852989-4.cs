    using Microsoft.JSInterop;
    [Inject]
    protected IJSRuntime jrt { get; set; }
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {
                var oid = await jrt.InvokeAsync<string>("GetOperationId");
                int opid;
                if (int.TryParse(oid, out opid))
                    OperationId = opid;
            }
            catch (Exception ex)
            {
                ls?.LogException(ex, "Sortiment.OnAfterRenderAsync");
            }
            //This code was moved from OnInitializedAsync which executes without parameter value
            if (OperationId.HasValue)
                sortiment = await ProductService.GetSortimentAsync(null, OperationId, Odpady);
            else
                productFilter = await ProductService.GetProductFilterAsync();
            StateHasChanged(); //Necessary, because the StateHasChanged does not fire automatically here
        }
    }
