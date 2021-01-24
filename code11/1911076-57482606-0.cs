    public interface ITypeA { }
    public interface ITypeB { }
    public class DescendantA1 : ITypeA { }
    public class DescendantA2 : ITypeA { }
    public class DescendantB1 : ITypeB { }
    public class DescendantB2 : ITypeB { }
    public interface ITypeMapper<in TTypeA, out TTypeB>
    {
        TTypeB Map(TTypeA typeA);
    }
    public abstract class TypesMapper<TTypeA, TTypeB>: ITypeMapper<ITypeA, ITypeB>
        where TTypeA : ITypeA
        where TTypeB : ITypeB 
    {
        public ITypeB Map(ITypeA typeA) => internalMap(typeA);
        protected abstract TTypeB internalMap(TTypeA a);
    }
    public class FirstMapper : TypesMapper<DescendantA1, DescendantB1>
    {
        protected override DescendantB1 internalMap(DescendantA1 typeA) => throw new NotImplementedException();
    }
    public class SecondMapper : TypesMapper<DescendantA2, DescendantB2>
    {
        protected override DescendantB2 internalMap(DescendantA2 typeA) => throw new NotImplementedException();
    }
    public static class ProgramTest
    {
        static void Main(string[] args)
        {
            List<ITypeMapper<ITypeA, ITypeB>> types = new List<ITypeMapper<ITypeA, ITypeB>>();
            types.Add(new FirstMapper());
            types.Add(new SecondMapper());
        }
    }
