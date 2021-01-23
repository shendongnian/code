            private void CoverArt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Storyboard AnimFadeOut = new Storyboard();
            AnimFadeOut.Completed += new EventHandler(ImageFadeOut_Completed);
            DoubleAnimation FadeOut = new DoubleAnimation();
            FadeOut.From = 1.0;
            FadeOut.To = 0.0;
            FadeOut.Duration = new Duration(TimeSpan.FromSeconds(.5));
            AnimFadeOut.Children.Add(FadeOut);
            Storyboard.SetTargetName(FadeOut, CurrentCover.Name);
            Storyboard.SetTargetProperty(FadeOut, new PropertyPath(Image.OpacityProperty));
            AnimFadeOut.Begin(this);
        }
        void ImageFadeOut_Completed(object sender, EventArgs e)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            image.UriSource = new Uri("Minogue.jpg", UriKind.Relative);
            image.EndInit();
            CurrentCover.Source = image;
            Storyboard ImageFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            ImageFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, CurrentCover.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            ImageFadeIn.Begin(this);
        }
