    public class MyClassFactory
    {  
        private static List<Tuple<IFactoryRule, Func<IMyClass>>> _rules = new List();
    
        static MyClassFactory()
        {
            // rules are evaluated in this same order
            _rules.Add(new SimpleRule(1,2,3), () => new SimpleInst());
            _rules.Add(new ComplexRule(p => p.a + p.b == p.c), () => new ComplexInst());
        }
    }
