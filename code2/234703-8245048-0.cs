    string userName = System.Web.HttpContext.Current.Server.UrlDecode(userName);
    RouteTable.Routes.MapRoute(
                "AdminPassword", // routename 
                "ControlPanel/changeUserPassword/" + userName,
                new { controller = "ControlPanel", action = "changeUserPassword", username = UrlParameter.Optional }
                ); 
