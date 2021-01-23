    public class MyClassFactory
    {  
        private static List<Tuple<IFactoryRule, Func<IMyClass>>> _rules = new List();
    
        static MyClassFactory()
        {
            // rules are evaluated in this same order
            _rules.Add(new SimpleRule(1,2,3), () => new Simple());
            _rules.Add(new ComplexRule(p => p.a + p.b == p.c), () => new Complex());
        }
        public static IMyClass Create(PropertySet pset)
        {
            if (pset == null)
                throw new ArgumentNullException("pset");
            // try to find a match
            Tuple<IFactoryRule, Func<IMyClass>> rule = 
                _rules.FirstOrDefault(r => r.First.CanInstantiate(pset));
            if (rule == null)
                throw new ArgumentException(
                    "Unsupported property set: " + pset.ToString());
            // invoke constructor delegate
            return rule.Second();
        }
    }
