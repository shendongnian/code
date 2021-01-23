		private void Form1_Load( object sender, EventArgs e )
		{
			DB db = DB.Instance;
			dataGridView1.DataSource = db.GetCategoryTable( );
			dataGridView2.DataSource = db.GetCategoryTable( );
			dataGridView3.DataSource = db.GetStatusTable( );
		}
