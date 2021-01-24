    public static class SN
    {
        private static string CardNumber
        {
            get => (string)HttpContext.Current.Session["CardNumber"];
            set => HttpContext.Current.Session["CardNumber"] = value;
        }
    }
