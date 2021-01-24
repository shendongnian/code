    public class Obj
    	{
    		public string Name;
    		public Obj(string name)
    		{
    			Debug.LogFormat("HI");
    			this.Name = name;
    		}
    	}
            var list1 = "a,b"
    			   .Split(',')
    			   .Select(x => new Obj(x));
            foreach (var v in list1)
    		{ }
