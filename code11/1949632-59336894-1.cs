        public partial class SelectWithFilter<TValue> : InputBase<TValue>
        {
                [Parameter] public string Id { get; set; }
                [Parameter] public string Label { get; set; }
                [Parameter] public bool Required { get; set; }
                //[Parameter] public Expression<Func<string>> ValidationFor { get; set; }
                [Parameter] public ICollection<KeyValuePair<string, string>> Datasource { get; set; }
                [Inject] IJSRuntime JSRuntime { get; set; }
                public DotNetObjectReference<SelectWithFilter<TValue>> DotNetRef;
                protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
                {
                    if (value == "null")
                    {
                        value = null;
                    }
                    if (typeof(TValue) == typeof(string))
                    {
                        result = (TValue)(object)value;
                        validationErrorMessage = null;
        
                        return true;
                    }
                    else if (typeof(TValue) == typeof(int) || typeof(TValue) == typeof(int?))
                    {
                        int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
                        result = (TValue)(object)parsedValue;
                        validationErrorMessage = null;
        
                        return true;
                    }
        
                    throw new InvalidOperationException($"{GetType()} does not support the type '{typeof(TValue)}'.");
                }
        
                protected override void OnInitialized()
                {
                    base.OnInitialized();
                    DotNetRef = DotNetObjectReference.Create(this);
                }
        
                protected override async Task OnAfterRenderAsync(bool firstRender)
                {
                    await base.OnAfterRenderAsync(firstRender);
                    if (firstRender)
                    {
                        await JSRuntime.InvokeVoidAsync("select2Component.init", Id);
                        await JSRuntime.InvokeVoidAsync("select2Component.onChange", Id, DotNetRef, "Change_SelectWithFilterBase");
                    }
                }
        
                [JSInvokable("Change_SelectWithFilterBase")]
                public void Change(string value)
                {
                    if (value == "null")
                    {
                        value = null;
                    }
                    if (typeof(TValue) == typeof(string))
                    {
                        CurrentValue = (TValue)(object)value;
                    }
                    else if (typeof(TValue) == typeof(int))
                    {
                        int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
                        CurrentValue = (TValue)(object)parsedValue;
                    }
                    else if (typeof(TValue) == typeof(int?))
                    {
                        if (value == null)
                        {
                            CurrentValue = (TValue)(object)null;
                        }
                        else
                        {
                            int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsedValue);
                            CurrentValue = (TValue)(object)parsedValue;
                        }
                    }
                }
            }
