        private async void ControlDesignTimeUIUpdater()
        {
            double OldImageWidth = ImageWidth;
            double OldImageHeight = ImageHeight;
            CornerRadius OldImageCornerRadius = ImageCornerRadius;
            double OldBorderThickness = BorderThickness;
            ImageSource OldMyImageSource = MyImageSource;
            while (this.IsLoaded)
            {
                //CHECK CHANGES DELAY 100ms
                await Task.Delay(100);
                //MAKE SURE CONTROL IS INITIALIZED BEFORE ANY UI UPDATES
                if (IsControlInitialized)
                {
                    if (OldImageWidth != ImageWidth)
                    {
                        OldImageWidth = ImageWidth;
                        SetImageWidth();
                    }
                    if (OldImageHeight != ImageHeight)
                    {
                        OldImageHeight = ImageHeight;
                        SetImageHeight();
                    }
                    if (OldImageCornerRadius != ImageCornerRadius)
                    {
                        OldImageCornerRadius = ImageCornerRadius;
                        SetImageCornerRadius();
                    }
                    if (OldBorderThickness != BorderThickness)
                    {
                        OldBorderThickness = BorderThickness;
                        SetBorderThickness();
                    }
                    if (OldMyImageSource != MyImageSource)
                    {
                        OldMyImageSource = MyImageSource;
                        SetMyImageSource();
                    }
                    //
                    // ETC.
                    //
                }
            }
        }
