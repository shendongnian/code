	public class Person 
	{
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
				if(String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
				{
					value = "NA";
				}
                _name = value;
            }
        }
	   public Person(string name)
	   {
		  this.Name = name;
	   }
	}
	
