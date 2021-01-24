    namespace xxxxx
    {
        public static class MailContainer
        {
            public static string TheObjectPropertyEmail
            {
                get
                {
                    return HttpContext.Current.Session["TheObjectPropertyEmail"].ToString();
                }
                set
                {
                    HttpContext.Current.Session["TheObjectPropertyEmail"] = value;
                }
             } 
        }
    }
