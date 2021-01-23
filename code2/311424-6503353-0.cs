		public class DataLayer {
			public DataLayer(IDbHelper dbHelper){
				this.DbHelper = dbHelper;
			}
			public IDbHelper DbHelper { get; private set; }
	
			public void RunQuery(){
				// Do stuff with dbhelper
			}
		}
