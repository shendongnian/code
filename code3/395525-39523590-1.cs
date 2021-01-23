    void Main()
    {
    	var Person = new Person(){FirstName = "Egli", LastName = "Becerra"};
    	
    	//Will update egli
        WontUpdate(Person);
    	Console.WriteLine("WontUpdate");
        Console.WriteLine($"First name: {Person.FirstName}, Last name: {Person.LastName}\n");
    	
    	UpdateImplicitly(Person);
    	Console.WriteLine("UpdateImplicitly");
        Console.WriteLine($"First name: {Person.FirstName}, Last name: {Person.LastName}\n");
    
        UpdateExplicitly(ref Person);
    	Console.WriteLine("UpdateExplicitly");
        Console.WriteLine($"First name: {Person.FirstName}, Last name: {Person.LastName}\n");
    }
    
    //Class to test
    public class Person{
    	public string FirstName {get; set;}
    	public string LastName {get; set;}
    	
    	public string printName(){
    		return $"First name: {FirstName} Last name:{LastName}";
    	}
    }
    
    public static void WontUpdate(Person p)
    {
        //New instance does jack...
    	var newP = new Person(){FirstName = p.FirstName, LastName = p.LastName};
    	newP.FirstName = "Favio";
    	newP.LastName = "Becerra";
    }
    
    public static void UpdateImplicitly(Person p)
    {
        //Passing by reference implicitly
    	p.FirstName = "Favio";
    	p.LastName = "Becerra";
    }
    
    public static void UpdateExplicitly(ref Person p)
    {
        //Again passing by reference explicitly (reduntant)
    	p.FirstName = "Favio";
    	p.LastName = "Becerra";
    }
