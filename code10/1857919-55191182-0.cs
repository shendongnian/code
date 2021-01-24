    public static List<HolderClass<T>> TextFileDeSerialize<T>(string filename)
    {
        List<HolderClass<T>> obj = null;
        StreamReader reader = new StreamReader(filename);
        try
        {
            while (!reader.EndOfStream)
            {
				HolderClass<T> c = new HolderClass<T>();
				c.stringVal = reader.ReadLine();
                //c.appleVal = whatever
                obj.Add(c);
            }              
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
        return obj;
    }
	public class HolderClass<T> {
		public string stringVal;
		public T appleVal;
		
		public HolderClass() {
		}
	}
If your intent is to not return a list of objects, I would do something like this.
You could then have the types you wanted to pass as generics be extensions of holderClass.
    public static HolderClass TextFileDeSerialize<T>(string filename, HolderClass h)
    {
        StreamReader reader = new StreamReader(filename);
        try
        {
            while (!reader.EndOfStream)
            {
				h.stringVal.Add(reader.ReadLine());
            }              
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
        return h;
    }
	
	public class HolderClass {
		public List<string> stringVal;
		
		public HolderClass() {
			stringVal = new List<string>();
		}
		
		//Add whatever functionality you'd want in your original class you had passing in as the generic
	}
