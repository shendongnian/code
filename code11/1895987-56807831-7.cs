    public class MyClass
    { 
         public int Id; 
         public int Id2;
         public int Id3;
		 public Expression<Func<MyClass,object>>[] GetPKs() 
                           => new Expression<Func<MyClass,object>>[] { x=>Id, x=>Id2 };
    	 public IEnumerable<string> GetPNames()
		 {
			return GetPKs().Select(expr =>
                  ((MemberExpression)((UnaryExpression)expr.Body).Operand).Member.Name);
		 }
    }
	
