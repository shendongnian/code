     public async Task<Bitmap> GetBitmapFromUrlAsync(String src)
        {
            try
            {
                URL url = new URL(src);
                HttpURLConnection connection = (HttpURLConnection)url.OpenConnection();
                connection.DoInput = (true);
                await connection.ConnectAsync();
                Stream input = connection.InputStream;
                Bitmap myBitmap = await BitmapFactory.DecodeStreamAsync(input);
                return myBitmap;
            }
            catch (IOException e)
            {
                // Log exception
                return null;
            }
        }
