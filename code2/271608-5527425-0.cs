    /// <summary>
    /// This method takes in an ArrayList of unsorted numbers in the format: a:b
    /// and returns a sorted List<string> with a descending, b ascending
    /// <summary>
    public List<string> SortMyValues(ArrayList unsorted)
    {
    	// Declare an empty, generic List of type 'TwoNumbers'
    	List<MyTuple> values = new List<MyTuple>();
    	foreach (object item in unsorted)
    	{
    		char[] splitChar = new char[] { ':' };
    		string itemString = item as string;
    		string[] s = itemString.Split(splitChar);
    		values.Add(new MyTuple{
    			FirstNumber = int.Parse(s[0]),
    			SecondNumber = int.Parse(s[1])
    		});
    	}
    	// Sort the values
    	values.Sort();
    	// Return a list of strings, in the format given
    	List<string> sorted = new List<string>();
    	foreach (MyTuple item in values)
    	{
    	    sorted.Add(item.FirstNumber + ":" + item.SecondNumber);
    	}
    	return sorted;
    }
    
    public class MyTuple : IComparable {
    	public int FirstNumber { get; set; }
    	public int SecondNumber { get; set; }
    	
    	public int CompareTo(object obj)
        {
    	    if (obj is MyTuple)
    	    {
    	        MyTuple other = (MyTuple)obj;
    		
                // First number descending
    	        if (FirstNumber != other.FirstNumber)
    		    return other.FirstNumber.CompareTo(FirstNumber);
    	        // Second number ascending
    		return SecondNumber.CompareTo(other.SecondNumber);
    	    }
    	    throw new ArgumentException("object is not a MyTuple");
    	}
    }
