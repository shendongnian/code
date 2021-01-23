    public object ListingBG
            {
                get
                {
                    if (!string.IsNullOrEmpty(ListingBGString))
                    {
                        // bind Image
                        return new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri(ListingBGString, UriKind.RelativeOrAbsolute))
                        };
                    }
                    // bind color hex (RGB hex or RGB+Alpha hex)
                    return "#FFFFFFFF";
                }
            }
