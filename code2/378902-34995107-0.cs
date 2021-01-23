    public class MyDB : DbContext
    {
        public MyDB()
        {
             this.Database.Log = x => { Debug.WriteLine(x); };
        }
	}
