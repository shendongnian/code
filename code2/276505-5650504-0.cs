                var icon = Imaging.CreateBitmapSourceFromHIcon(
                  sysicon.Handle,
                  System.Windows.Int32Rect.Empty,
                  System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                icon.Freeze();
                Dispatcher.Invoke(new Action(() => this.Icon = icon));
