    Button button = new Button();
                ControlTemplate ct = this.Resources["buttonTemplate"] as ControlTemplate;
                Image img = ct.LoadContent() as Image;
                img.Source = new BitmapImage(new Uri(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg",UriKind.RelativeOrAbsolute));
                button.Template = ct;
                button.Height = 200;
                button.Width = 200;
                layoutRoot.Children.Add(button);
