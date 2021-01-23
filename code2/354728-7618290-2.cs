	interface IServiceAcceptor
	{
		string Accept(FilterService service);
	}
	public class Filter : IServiceAcceptor
	{
		string IServiceAcceptor.Accept(FilterService service)
		{
			return service.GetFilterText(this);
		}	
	}
	public class DistrFilter : Filter, IServiceAcceptor
	{
		string IServiceAcceptor.Accept(FilterService service)
		{
			return service.GetFilterText(this);
		}		
	}
	public class ReportFilter : Filter, IServiceAcceptor
	{
		string IServiceAcceptor.Accept(FilterService service)
		{
			return service.GetFilterText(this);
		}		
	}
