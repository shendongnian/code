    using System;
    	
    public interface MA {}
    public static class MAProvider {
    	public static void A(this MA obj) { Console.WriteLine("MA"); }
    }
    
    public interface MB {}
    public static class MBProvider {
    	public static void B(this MB obj) { Console.WriteLine("MB"); }
    }
    
    public interface MC {}
    public static class MCProvider {
    	public static void C(this MC obj) { Console.WriteLine("MC"); }
    }
    
    public interface MD {}
    public static class MDProvider {
    	public static void D(this MD obj) { Console.WriteLine("MD"); }
    }
    
    public class First : MA, MB, MC {}
    public class Second : MB, MD {}
    public class Third : MA, MC, MD {}
    
    public static class Program {
    	public static void Main() {
    		new First().A();
    		new First().B();
    		new First().C();
    		
    		new Second().B();
    		new Second().D();
    		
    		new Third().A();
    		new Third().C();
    		new Third().D();
    	}
    }
