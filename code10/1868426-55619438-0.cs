    public class Employee
    {
        public int ID;
        public string Name;
        public string Description;
		
		public Employee(int ID, string Name, string Description)
		{
			this.ID = ID;
			this.Name = Name;
			this.Description = Description;
		}
		
		public override string ToString()
		{
			return $"{ID}, {Name}, {Description}";
		}
    }
