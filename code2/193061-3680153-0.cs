    public interface IReportModule
	{
	}
	public interface IReportModuleFactory
	{
		IReportModule Create();
	}
	private static IReportModule CreateReportModuleFromRawAssemby(byte[] rawAssembly)
	{
		var reportModule = Assembly.Load(rawAssembly);
		var factoryType = reportModule.GetExportedTypes()
			.FirstOrDefault(x => x.IsAssignableFrom(typeof(IReportModuleFactory)));
		if (factoryType != null)
		{
			var reportModuleFactory = (IReportModuleFactory)
				reportModule.CreateInstance(factoryType.FullName);
			return reportModuleFactory.Create();
		}
		else
			throw new NotImplementedException("rawAssembly does not implement IReportModuleFactory");
	}
