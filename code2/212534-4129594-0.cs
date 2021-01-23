        public static string GetSessionCulture(ControllerContext controllerContext)
        {
            return Convert.ToString(controllerContext.HttpContext.Session["culture"]);
        }
        public static void SetSessionCulture(ControllerContext controllerContext, string culture)
        {
            controllerContext.HttpContext.Session["culture"] = culture;
        }
