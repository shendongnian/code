    <div>
      <InputText type="text" @bind-Value="@BindingValue" />
    </div>
    
    @code {
    
        private string _value;
    
        [Parameter]
        public string BindingValue
        {
            get => _value;
            set
            {
                if (_value == value ) return;
                _value = value;
                BindingValueChanged.InvokeAsync(value);
            }
        }
    
        [Parameter]
        public EventCallback<string> BindingValueChanged { get; set; }   
    
    }
