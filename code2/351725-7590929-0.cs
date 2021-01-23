    private Drawable GetDrawable(string url)
    {
        try {
            HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            using (Stream responseStream = response.GetResponseStream()) {
                MemoryStream workaround = new MemoryStream();
                responseStream.CopyTo(workaround);
			
                Bitmap bitmap = Android.Graphics.BitmapFactory.DecodeByteArray (
                        workaround.GetBuffer (), 0, (int) workaround.Length);
                Drawable image = new BitmapDrawable(bitmap);
                return image;
            }
        }
        catch (Exception e) {
            Log.Error("DrawableTest", "Exception: " + e.Message);
            return null;
        }
    }
