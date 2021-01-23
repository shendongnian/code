        public override string GetVaryByCustomString(HttpContext context, string arg)
        {
            if (arg.Equals("FullURL", StringComparison.InvariantCultureIgnoreCase)
            {
                return context.Request.RawUrl;
            }
            else
            {
                return string.Empty;
            }
        }
