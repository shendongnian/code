    public abstract class Creator<ProductType, SpecType>
    {
        public Creator(SpecType aSpec) { _aSpecification = aSpec; }
        public SpecType GetSpecification() { return _aSpecification; }
        public abstract ProductType Create();
        private SpecType _aSpecification;
    }
    public class ConcreteCreator<ProductType, ConcreteProductType, SpecType> : Creator<ProductType, SpecType> where ConcreteProductType : ProductType, new()
    {
        public ConcreteCreator(SpecType aSpec) : base(aSpec) { }
        public override ProductType Create() { return new ConcreteProductType(); }
    }
