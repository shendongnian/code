		public override string Url
		{
			get
			{
				if (!string.IsNullOrEmpty(this.url))
					return this.url;
				RequestContext ctx;
				if (HttpContext.Current.Handler is MvcHandler)
					ctx = ((MvcHandler)HttpContext.Current.Handler).RequestContext;
				else
					ctx = new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData());
				var routeValues = new RouteValueDictionary(RouteValues);
				foreach (var key in DynamicParameters)
					routeValues.Add(key, ctx.RouteData.Values[key]);
				return new UrlHelper(ctx).Action(Action, Controller, routeValues);
			}
			set
			{
				this.url = value;
			}
		}
