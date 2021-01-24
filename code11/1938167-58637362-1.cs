                BindingContext = vm = new HomeViewModel();
    
                InitializeComponent();
    
                Chart1.Chart = new BarChart { Entries = entries, LabelTextSize = (float)Convert.ToDouble(Device.GetNamedSize(NamedSize.Large, typeof(Label))), BackgroundColor = SKColors.Transparent };
    
    
    
            }
