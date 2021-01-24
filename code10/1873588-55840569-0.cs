        private void Start()
        {
            for (int i = 0; i < MaxRow; i++)
            {
                for (int j = 0; j < MaxCol; j++)
                {
                    string current = $"ImgR{i}C{j}";
                    object currentImg = Application.Current.Dispatcher.Invoke(() => this.FindName(current));
                    if (currentImg?.GetType() == typeof(Image))
                    {
                        var img = ((Image) currentImg);
                        Thread.Sleep(100);
                        Application.Current.Dispatcher.Invoke(() => img.Visibility = Visibility.Visible);
                        
                        //DoEvents();
                        //Thread.Sleep(100);
                        //Application.Current.Dispatcher.Invoke(() => img.Visibility = Visibility.Visible);
                        //DoEvents();
                    }
                }
            }
        }
