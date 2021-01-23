        public string CurrentUserName
        {
            get
            {
                var context = HttpContext.Current;
                if ( context != null && context.User != null && context.User.Identity != null )
                    return HttpContext.Current.User.Identity.Name;
                else
                    return null;
            }
        }
