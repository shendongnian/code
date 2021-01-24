     <div class="pop-container">
            @if (Show)
            {
                <div class="popconfirm">
                    @Message
                    <button type="button" class="btn btn-warning" @onclick="() => Confirmation(false)">No</button>
                    <button type="button" class="btn btn-primary" @onclick="() => Confirmation(true)">Yes</button>
                </div>
        
            }
            <button type="button" class="@Class" @onclick="ShowPop">@Title</button>
        </div>
        @code {
            public bool Show { get; set; }
            [Parameter] public string Title { get; set; } = "Delete";
            [Parameter] public string Class { get; set; } = "btn btn-danger";
            [Parameter] public string Message { get; set; } = "Are you sure?";
            [Parameter] public EventCallback<bool> ConfirmedChanged { get; set; }
        
            public async Task Confirmation(bool value)
            {
                Show = false;
                await ConfirmedChanged.InvokeAsync(value);
            }
        
            public void ShowPop()
            {
                Show = true;
            }
        }
