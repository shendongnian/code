    RazorInputTextTest.razo
    -----------------------
    @page  "/RazorInputTextTest"
    
    <span>Name of the category: @category.Name</span>
    
    <EditForm Model="@category">
       <RazorInputText Value="@category.Name" ValueChanged="@OnValueChanged" ValueExpression="@(() => category.Name)" />
    
    </EditForm>
    
       
    @code{
        private Category category { get; set; } = new Category { ID = "1", Name = "Beverages" };
    
    
        private void OnValueChanged(string name)
        {
    
            category.Name = name;
        }
    
    }
    
     RazorInputText.razor
     --------------------
    <div class="form-group">
        <InputText class="form-control" @bind-Value="@Value"></InputText>
    </div>
    
    @code{
    
        private string _value { get; set; }
    
        [Parameter]
        public string Value
        {
            get { return _value; }
            set
            {
                if (_value != value) {
                    _value = value;
                    if (ValueChanged.HasDelegate)
                    {
                        ValueChanged.InvokeAsync(value);
                    }
                }
              
    
            }
        }
    
    
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public Expression<Func<string>> ValueExpression { get; set; }
    }
