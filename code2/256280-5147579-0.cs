	public sealed class DB
	{
		private static readonly DB instance = new DB( );
		public static DB Instance { get { return instance; } }
		static DB( ) { }
		private DB( ) 
		{
			StaticData = new DataSet( );
		}
		private static DataSet StaticData;
		public DataTable GetCategoryTable( )
		{
			// check if the table has been created
			if( StaticData.Tables["Category"] == null )
			{
				// build table (or retrieve from database)
				DataTable table = new DataTable( );
				table.TableName = "Category";
				table.Columns.Add( "ID", typeof( int ) );
				table.Columns.Add( "Name", typeof( string ) );
				table.Columns.Add( "Description", typeof( string ) );
				table.Rows.Add( 1, "Beverages", "Soft drinks, coffees, teas, beers, and ales" );
				table.Rows.Add( 2, "Condiments", "Sweet and savory sauces, relishes, spreads, and seasonings" );
				table.Rows.Add( 3, "Produce", "Dried fruit and bean curd" );
				table.Rows.Add( 4, "Seafood", "Seaweed and fish" );
				table.Rows.Add( 5, "Meat/Poultry", "Prepared meats" );
				StaticData.Tables.Add(table.Copy());
			}
			return StaticData.Tables["Category"];	
		}
		public DataTable GetStatusTable( )
		{
			// check if the table has been created
			if( StaticData.Tables["Status"] == null )
			{
				// build table (or retrieve from database)
				DataTable table = new DataTable( );
				table.TableName = "Status";
				table.Columns.Add( "ID", typeof( int ) );
				table.Columns.Add( "Name", typeof( string ) );
				table.Columns.Add( "Description", typeof( string ) );
				table.Rows.Add( 1, "Active", "Active" );
				table.Rows.Add( 2, "Retired", "Retired" );
				StaticData.Tables.Add( table.Copy( ) );
			}
			return StaticData.Tables["Status"];
		}
	}
