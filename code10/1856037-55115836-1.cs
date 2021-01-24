       public partial class MainPage : ContentPage
        {
            Label[] lb;
            Button[] btn;
            StackLayout[] sl;
            int i = 0;
    
            public MainPage()
            {
                InitializeComponent();
                sl = new StackLayout[10];
                lb = new Label[10];
                btn = new Button[lb.Length];
                StackLayout content = new StackLayout();
                for (i = 0; i < lb.Length; i++)
                {
                    lb[i] = new Label()
                    {
                        Text = "Old Text"+i,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    btn[i] = new Button
                    {
                        Text = "Click to Change Label Text!"+i,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.Center,
                    };
                    btn[i].Clicked += (sender, e) => Button_Clicked(sender, e);
                    // TODO Somehow reference the Label in the Button Clicked Method
                    sl[i] = new StackLayout
                    {
                        ClassId = ""+i,
                        Children =
                        {
                            lb[i],
                            btn[i]
                        }
                    };
                    content.Children.Add(sl[i]);
                }
                Content = content;
    
            }
            // Buton Clicked Method
            private void Button_Clicked(object sender, EventArgs e)
            {
                Button bt = sender as Button;
                StackLayout layout = bt.Parent as StackLayout;
                int index = Int32.Parse(layout.ClassId);
                lb[index].Text = "Hello World!" + index;
            }
        }
