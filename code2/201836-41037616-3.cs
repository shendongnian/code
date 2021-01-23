	void Main()
	{
	
		//odd os are null; evens are not null
		object o1 = null;
		object o2 = new object();
		object o3 = null;
		object o4 = new object();
		object o5 = o1;
		object o6 = o2;
		
		Demo d1 = new Demo(Guid.Empty);
		Demo d2 = new Demo(Guid.NewGuid());
		Demo d3 = new Demo(Guid.Empty);
		
		Debug.WriteLine("comparing null with null always yields true...");
		ShowResult("ReferenceEquals(o1, o1)", () => ReferenceEquals(o1, o1)); //true
		ShowResult("ReferenceEquals(o3, o1)", () => ReferenceEquals(o3, o1)); //true
		ShowResult("ReferenceEquals(o5, o1)", () => ReferenceEquals(o5, o1)); //true 
		ShowResult("o1 == o1", () => o1 == o1); //true
		ShowResult("o3 == o1", () => o3 == o1); //true
		ShowResult("o5 == o1", () => o5 == o1); //true 
		
		Debug.WriteLine("...though because the object's null, we can't call methods on the object (i.e. we'd get a null reference exception).");
		ShowResult("o1.Equals(o1)", () => o1.Equals(o1)); //NullReferenceException
		ShowResult("o1.Equals(o2)", () => o1.Equals(o2)); //NullReferenceException
		ShowResult("o3.Equals(o1)", () => o3.Equals(o1)); //NullReferenceException
		ShowResult("o3.Equals(o2)", () => o3.Equals(o2)); //NullReferenceException
		ShowResult("o5.Equals(o1)", () => o5.Equals(o1));  //NullReferenceException
		ShowResult("o5.Equals(o2)", () => o5.Equals(o1));  //NullReferenceException
		
		Debug.WriteLine("Comparing a null object with a non null object always yeilds false");
		ShowResult("ReferenceEquals(o1, o2)", () => ReferenceEquals(o1, o2)); //false
		ShowResult("ReferenceEquals(o2, o1)", () => ReferenceEquals(o2, o1)); //false
		ShowResult("ReferenceEquals(o3, o2)", () => ReferenceEquals(o3, o2)); //false
		ShowResult("ReferenceEquals(o4, o1)", () => ReferenceEquals(o4, o1)); //false
		ShowResult("ReferenceEquals(o5, o2)", () => ReferenceEquals(o3, o2)); //false
		ShowResult("ReferenceEquals(o6, o1)", () => ReferenceEquals(o4, o1)); //false
		ShowResult("o1 == o2)", () => o1 == o2); //false
		ShowResult("o2 == o1)", () => o2 == o1); //false
		ShowResult("o3 == o2)", () => o3 == o2); //false
		ShowResult("o4 == o1)", () => o4 == o1); //false
		ShowResult("o5 == o2)", () => o3 == o2); //false
		ShowResult("o6 == o1)", () => o4 == o1); //false
		ShowResult("o2.Equals(o1)", () => o2.Equals(o1)); //false
		ShowResult("o4.Equals(o1)", () => o4.Equals(o1)); //false
		ShowResult("o6.Equals(o1)", () => o4.Equals(o1)); //false
	
		Debug.WriteLine("(though again, we can't call methods on a null object:");
		ShowResult("o1.Equals(o2)", () => o1.Equals(o2)); //NullReferenceException
		ShowResult("o1.Equals(o4)", () => o1.Equals(o4)); //NullReferenceException
		ShowResult("o1.Equals(o6)", () => o1.Equals(o6)); //NullReferenceException
	
		Debug.WriteLine("Comparing 2 references to the same object always yields true");
		ShowResult("ReferenceEquals(o2, o2)", () => ReferenceEquals(o2, o2)); //true	
		ShowResult("ReferenceEquals(o6, o2)", () => ReferenceEquals(o6, o2)); //true <-- Interesting
		ShowResult("o2 == o2", () => o2 == o2); //true	
		ShowResult("o6 == o2", () => o6 == o2); //true <-- Interesting
		ShowResult("o2.Equals(o2)", () => o2.Equals(o2)); //true 
		ShowResult("o6.Equals(o2)", () => o6.Equals(o2)); //true <-- Interesting
		
		Debug.WriteLine("However, comparing 2 objects may yield false even if those objects have the same values, if those objects reside in different address spaces (i.e. they're references to different objects, even if the values are similar)");
		Debug.WriteLine("NB: This is an important difference between Reference Types and Value Types.");
		ShowResult("ReferenceEquals(o4, o2)", () => ReferenceEquals(o4, o2)); //false <-- Interesting
		ShowResult("o4 == o2", () => o4 == o2); //false <-- Interesting
		ShowResult("o4.Equals(o2)", () => o4.Equals(o2)); //false <-- Interesting
	
		Debug.WriteLine("We can override the object's equality operator though, in which case we define what's considered equal");
		Debug.WriteLine("e.g. these objects have different ids, so we treat as not equal");
		ShowResult("ReferenceEquals(d1,d2)",()=>ReferenceEquals(d1,d2)); //false
		ShowResult("ReferenceEquals(d2,d1)",()=>ReferenceEquals(d2,d1)); //false
		ShowResult("d1 == d2",()=>d1 == d2); //false
		ShowResult("d2 == d1",()=>d2 == d1); //false
		ShowResult("d1.Equals(d2)",()=>d1.Equals(d2)); //false
		ShowResult("d2.Equals(d1)",()=>d2.Equals(d1)); //false
		Debug.WriteLine("...whilst these are different objects with the same id; so we treat as equal when using the overridden Equals method...");
		ShowResult("d1.Equals(d3)",()=>d1.Equals(d3)); //true <-- Interesting (sort of; different to what we saw in comparing o2 with o6; but is just running the code we wrote as we'd expect)
		ShowResult("d3.Equals(d1)",()=>d3.Equals(d1)); //true <-- Interesting (sort of; different to what we saw in comparing o2 with o6; but is just running the code we wrote as we'd expect)
		Debug.WriteLine("...but as different when using the other equality tests.");
		ShowResult("ReferenceEquals(d1,d3)",()=>ReferenceEquals(d1,d3)); //false <-- Interesting (sort of; same result we had comparing o2 with o6; but shows that ReferenceEquals does not use the overridden Equals method)
		ShowResult("ReferenceEquals(d3,d1)",()=>ReferenceEquals(d3,d1)); //false <-- Interesting (sort of; same result we had comparing o2 with o6; but shows that ReferenceEquals does not use the overridden Equals method)
		ShowResult("d1 == d3",()=>d1 == d3); //false <-- Interesting (sort of; same result we had comparing o2 with o6; but shows that ReferenceEquals does not use the overridden Equals method)
		ShowResult("d3 == d1",()=>d3 == d1); //false <-- Interesting (sort of; same result we had comparing o2 with o6; but shows that ReferenceEquals does not use the overridden Equals method)
	
		Debug.WriteLine("For completeness, here's an example of overriding the == operator (wihtout overriding the Equals method; though in reality if overriding == you'd probably want to override Equals too).");
		Demo2 d2a = new Demo2(Guid.Empty);
		Demo2 d2b = new Demo2(Guid.NewGuid());
		Demo2 d2c = new Demo2(Guid.Empty);
		ShowResult("d2a == d2a", () => d2a == d2a); //true
		ShowResult("d2b == d2a", () => d2b == d2a); //false
		ShowResult("d2c == d2a", () => d2c == d2a); //true <-- interesting
		ShowResult("d2a != d2a", () => d2a != d2a); //false
		ShowResult("d2b != d2a", () => d2b != d2a); //true
		ShowResult("d2c != d2a", () => d2c != d2a); //false <-- interesting
		ShowResult("ReferenceEquals(d2a,d2a)", () => ReferenceEquals(d2a, d2a)); //true
		ShowResult("ReferenceEquals(d2b,d2a)", () => ReferenceEquals(d2b, d2a)); //false
		ShowResult("ReferenceEquals(d2c,d2a)", () => ReferenceEquals(d2c, d2a)); //false <-- interesting
		ShowResult("d2a.Equals(d2a)", () => d2a.Equals(d2a)); //true
		ShowResult("d2b.Equals(d2a)", () => d2b.Equals(d2a)); //false
		ShowResult("d2c.Equals(d2a)", () => d2c.Equals(d2a)); //false <-- interesting	
	}
	
		
	//this code's just used to help show the output in a friendly manner
	public delegate bool Statement();
	void ShowResult(string statementText, Statement statement)
	{
		try 
		{
			Debug.WriteLine("\t{0} => {1}",statementText, statement());
		}
		catch(Exception e)
		{
			Debug.WriteLine("\t{0} => throws {1}",statementText, e.GetType());
		}
	}
	
	class Demo
	{
	    Guid id;
	    public Demo(Guid id) { this.id = id; }
	    public override bool Equals(object obj)
	    {
	        return Equals(obj as Demo); //if objects are of non-comparable types, obj will be converted to null
	    }
	    public bool Equals(Demo obj)
	    {
	        if (obj == null)
	        {
	            return false;
	        }
	        else
	        {
	            return id.Equals(obj.id);
	        }
	    }
	    //if two objects are Equal their hashcodes must be equal
	    //however, if two objects hash codes are equal it is not necessarily true that the objects are equal
	    //i.e. equal objects are a subset of equal hashcodes
	    //more info here: https://stackoverflow.com/a/371348/361842
	    public override int GetHashCode()
	    {
	        return id.GetHashCode();
	    }
	}
	class Demo2
	{
		Guid id;
		public Demo2(Guid id)
		{
			this.id = id;
		}
		
		public static bool operator ==(Demo2 obj1, Demo2 obj2)
		{
			if (ReferenceEquals(null, obj1)) 
			{
				return ReferenceEquals(null, obj2); //true if both are null; false if only obj1 is null
			}
			else
			{
				if(ReferenceEquals(null, obj2)) 
				{
					return false; //obj1 is not null, obj2 is; therefore false
				}
				else
				{
					return obj1.id == obj2.id; //return true if IDs are the same; else return false
				}
			}
		}
		
		// NB: We also HAVE to override this as below if overriding the == operator; this is enforced by the compiler.  However, oddly we could choose to override it different to the below; but typically that would be a bad idea...
		public static bool operator !=(Demo2 obj1, Demo2 obj2)
		{
			return !(obj1 == obj2);
		}
	}
