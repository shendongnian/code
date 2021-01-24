     public static class Utils
     {
       public static Stream GetFromAssets(this Context context, string assetName)
        {
            AssetManager assetManager = context.Assets;
            Stream inputStream;
            try
            {
                using (inputStream = assetManager.Open(assetName))
                {
                    return inputStream;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
     }
