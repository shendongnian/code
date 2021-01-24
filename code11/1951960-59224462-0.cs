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
                private set
                {
                    HttpContext.Current.Session["TheObjectPropertyEmail"] = value;
                }
             } 
        }
    }
