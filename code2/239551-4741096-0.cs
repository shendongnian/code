    while (rdr.Read())
            {
                Route invRoute = new Route(rdr["url"].ToString(), new MvcRouteHandler());
                RouteValueDictionary defaults = new RouteValueDictionary();
                defaults.Add("controller", rdr["controller"].ToString());
                defaults.Add("action", rdr["action"].ToString());
                Array arrParams = rdr["parametersOpt"].ToString().Split(',');
                foreach (string i in arrParams)
                {
                    defaults.Add(i, UrlParameter.Optional);
                }
                invRoute.Defaults = defaults;
                routes.Add(rdr["name"].ToString(), invRoute);
            }
