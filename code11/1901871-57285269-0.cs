    public class BasePage : Page
    {
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
    
            this.BottomAppBar = new AppBar()
            {
                Background = new SolidColorBrush(Colors.Transparent),
                IsOpen = false,
                Content = new InAppNotification
                {
                    Content = new StackPanel
                    {
                        Children =
                        {
                        new TextBlock{ Text = "HEADER!"},
                        new TextBlock{Text = "Message"},
                        new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            Children=
                            {
                                new Button{Content = "ok"},
                                new Button {Content = "cancel"}
                            }
                        }
    
                        }
                    }
                }
            };
            base.OnNavigatedTo(e);
    
        }
        public void ShowNotification()
        {
            this.BottomAppBar.IsOpen = true;
            InAppNotification note = this.BottomAppBar.Content as InAppNotification;
            if (note != null)
                note.Show();
        }
    }
