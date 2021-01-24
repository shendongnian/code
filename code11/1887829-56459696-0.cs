    public interface IAnimal
    {
    	int NumberOfLegs { get;}
    }
    
    public interface IBabyAnimal<TGrownAnimal>
    	: IAnimal
    	where TGrownAnimal : IGrownAnimal
    {
    	TGrownAnimal WillGrowToBe();
    }
    
    public interface IGrownAnimal : IAnimal
    {
    	
    }
    
    public class Catepillar : IBabyAnimal<Butterfly>
    {
    	public int NumberOfLegs { get;} = 100;
    	public Butterfly WillGrowToBe() => new Butterfly();
    }
    
    public class Butterfly : IGrownAnimal
    {
    	public int NumberOfLegs { get; } = 0;
    }
