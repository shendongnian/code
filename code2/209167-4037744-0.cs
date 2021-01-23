    namespace Domain.App
    {
    	public class PresentationClass
    	{
    		private Collection<ISomeOutput> GetData(ISomeInput1 input)
    		{   
    			ServicesLogicContext logic = new ServicesLogicContext( (MyType) Identifier );
    			return logic.GetSomeData(input) as Collection<ISomeOutput>;
    		}
    		private IMethodResult ExecuteSomeAction(ISomeInput2 input)
    		{   
    			ServicesLogicContext logic = new ServicesLogicContext( (MyType) Identifier);
    			return logic.ExecuteSomeAction(input);
    		}
    	}
    }	
    
    namespace Domain.Logic
    {
    	public sealed class ServicesLogicContext : ServicesLogicContextBase
    	{
    		public IList<ISomeOutput> GetSomeData(ISomeInput1 input) 
    		{
    			DBServices services = DBServicesProvider.CreateServices(SomeIdentifier);
    			return DBServicesProvider.GetSomeData(input);
    		}
    		public IMethodResult ExecuteSomeAction(ISomeInput2 input)
    		{
    			DBServices services = DBServicesProvider.CreateServices(SomeIdentifier);
    			IMethodResult result = services.ExecuteSomeAction(input);
    			return result;
    		}
    	}
    }
    
    namespace Domain.Data
    {
    	public abstract class DBServices : IServices
    	{
    		public virtual IList<ISomeOutput> GetSomeData(ISomeInput1 input)  {...}
    		public virtual IMethodResult ExecuteSomeAction(ISomeInput2 input) {...}
    	}
    
    	public class DBServicesSpecific1 : DBServices
    	{
    		public override IList<ISomeOutput> GetSomeData(ISomeInput1 input)  {...}
    		public override IMethodResult ExecuteSomeAction(ISomeInput2 input) {...}
    	}
    
    	public class DBServicesSpecific2 : DBServices
    	{
    		public override IList<ISomeOutput> GetSomeData(ISomeInput1 input)  {...}
    		public override IMethodResult ExecuteSomeAction(ISomeInput2 input) {...}
    	}
    
    	public sealed class DBServicesProvider
    	{
    		public static DBServices CreateServices(MyType identifier)
    		{
    			DBServices result = null;		
    			switch(identifier) 
    			{
    				case MyType.Specific1: result = new DBServicesSpecific1(); break;
    				case MyType.Specific2: result = new DBServicesSpecific2(); break;		
    			}
    			return result;
    		}
    	}
    }
