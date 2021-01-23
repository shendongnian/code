    public static class MessageBox
    {
        public static void Show(string message)
        {
            HttpContext.Current.Response.Write(string.Format("<script>alert('{0}');</script>", message));
        }
    }
