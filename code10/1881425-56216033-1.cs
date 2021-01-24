     public static Size GetImageSize(string fileName)
            {
    
                if (Device.RuntimePlatform == Device.iOS)
                {
                    UIImage image = UIImage.FromFile(fileName);
                    return new Size((double)image.Size.Width, (double)image.Size.Height);
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    var options = new BitmapFactory.Options
                    {
                        InJustDecodeBounds = true
                    };
                    fileName = fileName.Replace('-', '_').Replace(".png", "");
                    var resId = Android.App.Application.Context.Resources.GetIdentifier(
                        fileName, "drawable", Android.App.Application.Context.PackageName);
                    BitmapFactory.DecodeResource(
                        Android.App.Application.Context.Resources, resId, options);
                    return new Size((double)options.OutWidth, (double)options.OutHeight);
                }
    
                return Size.Zero;
            }
