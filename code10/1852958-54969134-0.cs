    public static string GetUserNameInstagramUrl(string url)
                {
                    Uri uri = new Uri(url);            
                    return uri.Segments.Last().TrimEnd('/');
                }
