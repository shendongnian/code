    if(this.Context.Handler == null)
    {
                foreach (var route in RouteTable.Routes)
                {
                    var foundRoute = route.GetRouteData(new HttpContextWrapper(Context));
                    if(foundRoute==null)
                        continue;    
                 
                    if(foundRoute.RouteHandler is MvcRouteHandler)
                    {
                      // code
                      break;
                    }
                }
    }
