    public class MyTemplate: DataTemplateSelector
        {
            public DataTemplate InputFieldTemplate { get; set; }
            public DataTemplate EmptyTemplate { get; set; }
            public DataTemplate DurationTemplate { get; set; }
            public DataTemplate SignatureDetailTemplate {get; set;}
            public DataTemplate SignaturePhoneTemplate { get; set; }
            public DataTemplate DateTemplate { get; set; }
    
    
            protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
            {
                try
                {
                    ControlsViewModel viewModel = item as ControlsViewModel;
    
                    if (viewModel == null)
                    {
                        return EmptyTemplate;
                    }
    
    
                    if (viewModel.ControlType == Enums.CustomControl.InputField || viewModel.ControlType == Enums.CustomControl.TextField)
                        return InputFieldTemplate;
                    if (viewModel.ControlType == Enums.CustomControl.Duration)
                    {
                        return DurationTemplate;
                    }
                    if (viewModel.ControlType == Enums.CustomControl.Signature)
                    {
                        if(string.IsNullOrEmpty(viewModel.Disclaimer))
                        {
                            return SignatureDetailTemplate;
                        }
    
                        return SignaturePhoneTemplate;
                    }
    
    
    
                    return EmptyTemplate;
                }
                catch
                {
                    throw;
                }
            }
        }
