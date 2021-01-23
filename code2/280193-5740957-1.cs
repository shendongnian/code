    public interface IClass<TEnum>
    { 
        Dictionary<TEnum, ISecondClass> { get; } 
    }
    
    public abstract class ClassBase<TEnum> : IClass<TEnum>
    {
        public abstract Dictionary<TEnum, ISecondClass> { get; protected set;}
    }
    
    public class ConcreteClass : ClassBase<ConcreteEnum>
    {
        public override Dictionary<ConcreteEnum, ISecondClass> { get; protected set;}
    }
