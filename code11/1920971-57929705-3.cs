    <button class="btn btn-primary" @onclick="@(() => OnClick?.InvokeAsync(Item))">@ButtonText</button>
    
    @code {
        [Parameter]
        public string ButtonText { get; set; } = "Submit";
    
        public string Item { get; set; }
    
        [Parameter]
    public EventCallback<strig> OnClick { get; set; }
    
    }
