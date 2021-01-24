    public class MyTypeViewModel
    {
        public MyTypeViewModel(MyType obj)
        {
            Map(obj);
        }
        
		public int ID { get; set; }
		
		private void Map(MyType obj)
		{
		    this.ID = obj.ID;
		}
    }
