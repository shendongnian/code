     @inject INotificationService NotificationService
    
     protected override async Task OnInitializedAsync()
     {
         NotificationService.OnChange += OnNotify;
     }
     public async Task OnNotify()
     {
        await InvokeAsync(() =>
        {
            StateHasChanged();
        });
     }
