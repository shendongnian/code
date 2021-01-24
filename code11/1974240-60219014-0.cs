    <div style="border:solid 1px red">
       <h2>Child Component</h2>
        <input type="text" value="@Text" @oninput="@((args) => Text = 
          args.Value.ToString())" />
    </div>
    
    @code {
        private string text { get; set; }
    
        [Parameter]
        public string Text
        {
            get { return text; }
            set
            {
                if (text != value) {
                    text = value;
                    if (TextChanged.HasDelegate)
                    {
                        TextChanged.InvokeAsync(value);
                    }
                }
            }
        }
    
        [Parameter]
        public EventCallback<string> TextChanged { get; set; }
    }
