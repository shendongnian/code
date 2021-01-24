	public CommonModel GetSqlReport<T>(IModelWithCurrentUser<xyz> model, string queryName)
	{
		var sqlParameters = SqlHelpers.GetReportSqlParameters(model);
		var outputParameters = new Dictionary<string, object>() { { "TotalCount", default(int) } };
		var result = _queryExecutor.QueryWithOutputParameters<T>(queryName, sqlParameters, outputParameters);
		var totalCount = Convert.ToInt32(outputParameters["TotalCount"]);
		return RepositoryConverter.ToCommonDSModel<T>(result, model.Content, totalCount);
	}
	
	public static class RepositoryConverter
	{
		private static Dictionary<Type, Delegate> __map = new Dictionary<Type, Delegate>()
		{
			{ typeof(Roles), (Func<List<Roles>, xyz, long, CommonModel>)ToCommonDSModel },
			{ typeof(Locations), (Func<List<Locations>, xyz, long, CommonModel>)ToCommonDSModel },
			{ typeof(abc), (Func<List<abc>, xyz, long, CommonModel>)ToCommonDSModel },
		}
		public static CommonModel ToCommonDSModel<T>(List<T> data, xyz dtoModel, long itemsCount)
			=> ((Func<List<T>, xyz, long, CommonModel>)__map[typeof(T)])(data, dtoModel, itemsCount);
	
		public static CommonModel ToCommonDSModel(List<Roles> data, xyz dtoModel, long itemsCount) => /* implementation here */;
		public static CommonModel ToCommonDSModel(List<Locations> data, xyz dtoModel, long itemsCount) => /* implementation here */;
		public static CommonModel ToCommonDSModel(List<abc> data, xyz dtoModel, long itemsCount) => /* implementation here */;
	}
