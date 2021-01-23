        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var context = new HttpContextWrapper(HttpContext.Current);
            var rd = RouteTable.Routes.GetRouteData(context);
            // use rd
        }
