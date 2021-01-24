    public class ImpClass: SpecificInterface {  // An implementation of the more specific interface
        public event System.Action<SomeClass> doSomethingWithT { 
    		add { delegateSubs.Add(value); } 
    		remove { delegateSubs.Remove(value); } 
    	}
	
    	protected HashSet<System.Action<SomeClass>> delegateSubs = new HashSet<System.Action<SomeClass>>();
    }
