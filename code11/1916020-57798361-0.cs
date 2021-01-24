            if (request.GetConfiguration().Routes.GetRouteData(request)?.Values["MS_SubRoutes"] is IHttpRouteData[] candidateRoutes)
            {
                var routeTemplate = candidateRoutes.First().Route.RouteTemplate;
                // Add to Server Variables - so IIS can log the route too
                var variables = HttpContext.Current.Request.ServerVariables;
                variables.Set("HTTP_WebApiRoute", routeTemplate);
            }
