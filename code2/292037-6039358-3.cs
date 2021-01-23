    public static class HttpPostedFileBaseExtensions
    {
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0);
        }
    }
    enter code here
