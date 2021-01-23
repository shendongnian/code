		public Form1( )
		{
			InitializeComponent( );
			List<Item> list = new List<Item>( );
			list.Add( new Item( 1, "ITEM 001" ) );
			list.Add( new Item( 2, "ITEM 002" ) );
			list.Add( new Item( 3, "ITEM 003" ) );
			list.Add( new Item( 4, "ITEM 004" ) );
			list.Add( new Item( 5, "ITEM 005" ) );
			list.Add( new Item( 6, "ITEM 006" ) );
			list.Add( new Item( 7, "ITEM 007" ) );
			list.Add( new Item( 100, "SW-RED" ) );
			list.Add( new Item( 101, "SW-BLUE" ) );
			list.Add( new Item( 102, "SW-GREEN" ) );
			list.Add( new Item( 103, "SW-BLACK" ) );
			list.Add( new Item( 104, "SW-WHITE" ) );
            // convert list to table
			DataTable dt = new DataTable( );
			dt = Convert.ToDataTable<Item>( list );
			DataView view = dt.AsDataView( );
			view.RowFilter = "ItemID < 100";
			comboBox1.DataSource = view;
			comboBox1.ValueMember = "ItemID";
			comboBox1.DisplayMember = "Description";
		}
