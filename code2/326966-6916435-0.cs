	void Main()
	{
		var t1 = typeof(DerivedModel1);
		var t3 = typeof(DerivedModel3);
		
		var t1Hierarchy = new LinkedList<Type>();
		var t3Hierarchy = new LinkedList<Type>();
		getHierarchy(t1, t1Hierarchy);
		getHierarchy(t3, t3Hierarchy);
		
		var pairs = t1Hierarchy.Zip(t3Hierarchy, Tuple.Create);
		var common = pairs.TakeWhile(p => p.Item1 == p.Item2);
		var gcd = common.LastOrDefault();
	}
	void getHierarchy(Type t, LinkedList<Type> bases)
	{
		var baseType = t.BaseType;
		
		if (baseType == null)
		{
			return;
		}
		
		bases.AddFirst(baseType);
		getHierarchy(baseType, bases);
	}
	class BaseModel {}
	class DerivedModel1 : BaseModel {}
	class DerivedModel2 : BaseModel {}
	class DerivedModel3 : DerivedModel2 {}
