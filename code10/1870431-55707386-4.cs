    public class WorkerA : IWorker<SomeModelA>
    {
    	public Template Get(List<SomeModelA> someModels)
    	{
    		ProcessModels(someModels);
    		return new Template(); // let's say it's based on the result of ProcessModels
    	}
    
    	private void ProcessModels(List<SomeModelA> models)
    	{
    		var x = models.First();
    	}
    }
    
    public class WorkerB : IWorker<SomeModelB>
    {
    	public Template Get(List<SomeModelB> someModels)
    	{
    		ProcessModels(someModels);
    		return new Template(); // let's say it's based on the result of ProcessModels
    	}
    
    	private void ProcessModels(List<SomeModelB> models)
    	{
    		var x = models.First();
    	}
    }
