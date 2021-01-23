    public class MyFilter: FilterDefinition
    {
    	public MyFilter()
    	{
    		WithName("contractor").AddParameter("contractorId", NHibernate.NHibernateUtil.Int32);
    	}
    }
