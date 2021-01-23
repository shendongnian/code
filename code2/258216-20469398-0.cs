    public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom == "UserName")
            {
                if (context.Request.IsAuthenticated)
                {
                    return context.User.Identity.Name;
                }
                return null;
            }
        
            return base.GetVaryByCustomString(context, custom);
        }
