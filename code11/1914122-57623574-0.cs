       public class Foo
    {
      public int baz;
    }
    
    public class Bar 
    { 
      public uint baz; 
    }
    
    public class Program
    {
    	public static void Main()		
    	{
    		Mapper.CreateMap<Foo,Bar>().ForMember(dest => dest.baz, opt => opt.Condition(src => (src.baz >= 0)));
    			 
    		var foo1 = new Foo { baz=-1 };		
    		var bar1 = Mapper.Map<Bar>(foo1);
    											  
    		Console.WriteLine("bar1.baz={0}", bar1.baz);
    											  
    		var foo2 = new Foo{ baz=100 };
    		var bar2 = Mapper.Map<Bar>(foo2);
    											  
    
    		Console.WriteLine("bar2.baz={0}", bar2.baz);
    	}
    }
