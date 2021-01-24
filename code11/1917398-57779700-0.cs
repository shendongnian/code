     var context = new DefaultHttpContext();
     var routeDictionary = new RouteValueDictionary
     {
         { "some","path" }
     };
     context.Features.Set<IRoutingFeature>(new RoutingFeature());
     context.Features.Get<IRoutingFeature>().RouteData = new RouteData(routeDictionary);
     var inline = fixture.Create<DefaultInlineConstraintResolver>();
     var route = new Route(new TestRouter(), "/some/path", inline);
     var httpMethodRouteConstraint = new HttpMethodRouteConstraint("GET");
     route.Constraints.Add("httpMethod", httpMethodRouteConstraint);
     context.Features.Get<IRoutingFeature>().RouteData.Routers.Add(route);
     context.Request.Method = "GET";
     context.Request.Path = "/some/path";
     context.Response.Body = new MemoryStream();
     return context;
