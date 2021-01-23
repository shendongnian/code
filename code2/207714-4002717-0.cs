            bool IsAbsoluteUrl(string url)
            {
                try
                {
                    new Uri(url, UriKind.Absolute);
                }
                catch (UriFormatException)
                {
                    return false;
                }
                return true;
            }
