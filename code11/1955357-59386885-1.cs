    public Page3()
        {
            InitializeComponent();
          
            var image1 = new Image
            {
                Source = "a11.jpg",WidthRequest=70,HeightRequest=70
            };
            var label1 = new Label
            {
                Text = "abc"
            };
            var label2 = new Label
            {
                Text = "Bear found in the wild!",HeightRequest=20,VerticalTextAlignment=TextAlignment.Center,HorizontalTextAlignment=TextAlignment.Center
            };
            Grid secondG = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1,GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1,GridUnitType.Star) },
                },
            };      
           var scrollV = new ScrollView { Content = secondG };
            secondG.Children.Add(image1,0,0);
            secondG.Children.Add(label1,0,1);
            secondG.Children.Add(label2);
            Grid firstG = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1,GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1,GridUnitType.Star) },
                },
            };
            var labeltext = new Label
            {
                LineBreakMode = LineBreakMode.WordWrap,FontSize=14,
                Text = "FIXED HEADER DEMO"
            };
            firstG.Children.Add(labeltext, 0, 0);
            firstG.Children.Add(scrollV, 0, 1);
            Content = firstG;
        }
    }
