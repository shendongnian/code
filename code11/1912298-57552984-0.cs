    public override IDisposable Toast(ToastConfig config)
            {
                ToastPrompt toast = null;
    
                return this.DispatchAndDispose(
                    () =>
                    {
                        toast = new ToastPrompt
                        {
                            Message = config.Message,
                            //Stretch = Stretch.Fill,
                            TextWrapping = TextWrapping.WrapWholeWords,
                            MillisecondsUntilHidden = Convert.ToInt32(config.Duration.TotalMilliseconds)
                        };
                        if (config.Icon != null)
                            toast.ImageSource = new BitmapImage(new Uri(config.Icon));
    
                        if (config.MessageTextColor != null)
                            toast.Foreground = new SolidColorBrush(config.MessageTextColor.Value.ToNative());
    
                        if (config.BackgroundColor != null)
                            toast.Background = new SolidColorBrush(config.BackgroundColor.Value.ToNative());
    
                        toast.Show();
                    },
                    () => toast.Hide()
                );
            }
