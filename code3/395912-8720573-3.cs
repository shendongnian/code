	private static readonly Regex rxControllerParser = new Regex(@"^(?<areans>.+?)\.Controllers\.(?<controller>[^\.]+)Controller$", RegexOptions.CultureInvariant|RegexOptions.IgnorePatternWhitespace|RegexOptions.ExplicitCapture);
	public string RenderViewToString<TController, TModel>(string viewName, bool partial, Dictionary<string, object> viewData, TModel model) where TController: ControllerBase {
		if (viewName == null) {
			throw new ArgumentNullException("viewName");
		}
		using (StringWriter sw = new StringWriter()) {
			SimpleWorkerRequest workerRequest = new SimpleWorkerRequest("/", "", sw);
			HttpContextBase httpContext = new HttpContextWrapper(HttpContext.Current = new HttpContext(workerRequest));
			RouteData routeData = new RouteData();
			Match match = rxControllerParser.Match(typeof(TController).FullName);
			if (!match.Success) {
				throw new InvalidOperationException(string.Format("The controller {0} doesn't follow the common name pattern", typeof(TController).FullName));
			}
			string areaName;
			if (TryResolveAreaNameByNamespace<TController>(match.Groups["areans"].Value, out areaName)) {
				routeData.DataTokens.Add("area", areaName);
			}
			routeData.Values.Add("controller", match.Groups["controller"].Value);
			ControllerContext controllerContext = new ControllerContext(httpContext, routeData, (ControllerBase)FormatterServices.GetUninitializedObject(typeof(TController)));
			ViewEngineResult engineResult = partial ? ViewEngines.Engines.FindPartialView(controllerContext, viewName) : ViewEngines.Engines.FindView(controllerContext, viewName, null);
			if (engineResult.View == null) {
				throw new FileNotFoundException(string.Format("The view '{0}' was not found", viewName));
			}
			ViewDataDictionary<TModel> viewDataDictionary = new ViewDataDictionary<TModel>(model);
			if (viewData != null) {
				foreach (KeyValuePair<string, object> pair in viewData) {
					viewDataDictionary.Add(pair.Key, pair.Value);
				}
			}
			ViewContext viewContext = new ViewContext(controllerContext, engineResult.View, viewDataDictionary, new TempDataDictionary(), sw);
			engineResult.View.Render(viewContext, sw);
			return sw.ToString();
		}
	}
