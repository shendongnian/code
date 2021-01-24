    <input type="text" value="@Text" />
    
    @code
    {
        [Parameter] public string Text { get; set; }
        public void SetText(string text)
        {
            Text = text;
            StateHasChanged();
        }
        [ParameterAttribute] public Parent Parent { get; set; }
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Parent.AddToParent(this);
            }
        }
    }
