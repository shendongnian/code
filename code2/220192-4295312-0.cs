        try
                {
                    image.Source = new BitmapImage(new Uri(sampleimage, UriKind.Absolute));
                }
                catch (OutOfMemoryException)
                {
                    sampleimage  = "defaulticon.jpg";
                    image.Source = new BitmapImage(new Uri(sampleimage, UriKind.Absolute));
                }  
                 catch (Exception ex)
                {
                    sampleimage  = "defaulticon.jpg";
                    image.Source = new BitmapImage(new Uri(sampleimage, UriKind.Absolute));
                }  
