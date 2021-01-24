    public interface ISystem
    {
    	string Name {get;set;}
    	void UpdateData();
    }
    
    public interface ISystem<T> : ISystem
    {
    	T GetData();
    }
    
    public class Computer
    {
        public List<ISystem> AssociatedSystems = new List<ISystem>();
        .....
        foreach (var associatedSystem in this.AssociatedSystems)
    	{
    		associatedSystem.UpdateData();
    	}
    }
