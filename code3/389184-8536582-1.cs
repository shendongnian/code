    public class MyFilter: FilterDefinition
    {
    	public MyFilter()
    	{
    		WithName("contractor").WithCondition("Crew.ContractorId== :contractorId").AddParameter("contractorId", NHibernate.NHibernateUtil.Int32);
    	}
    }
