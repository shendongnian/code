            while (rdr.Read()) {
                var defaults = new Dictionary<string, object>() {
                                                                    {"controller", rdr["controller"].ToString()},
                                                                    {"action", rdr["action"].ToString()},
                                                                    {"id", UrlParameter.Optional}
                                                                };
                foreach (var param in rdr["parametersOpt"].ToString().Split(',')) {
                    defaults.Add("param", UrlParameter.Optional);
                }
                routes.MapRoute(
                    rdr["name"].ToString(),             // Route name
                    rdr["url"].ToString(),   // URL with parameters
                    defaults
                );
            }
