    namespace EnumerableContract
    {
        public class C
        {
            public int Length { get; private set; }
        }
        public class P
        {
            public IList<C> Children
            {
                get
                {
                    Contract.Ensures(Contract.Result<IList<C>>() != null);
                    Contract.Ensures(Contract.ForAll(Contract.Result<IList<C>>(), c => c != null));
                    var result = new ReadOnlyObservableCollection<C>(new ObservableCollection<C>(new[] { new C() }));
                
                    Contract.Assume(Contract.ForAll(result, c => c != null));
                    return result; //CodeContracts: ensures unproven Contract.ForAll(Contract.Result<IList<C>>(), c => c != null)
                }
            }
            public class Program
            {
                public static int Main(string[] args)
                {
                    foreach (var item in new P().Children)
                    {
                        Contract.Assert(item == null); //CodeContracts: assert is false
                        Console.WriteLine(item.Length);
                    }
                    return 0;
                }
            }
        }
    }
