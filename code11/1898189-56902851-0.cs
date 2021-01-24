    	private DataTable dt;
		public List<DataRow> ModifiedRowsList { get; private set; }
		public myClass()
		{
			dt = new DataTable();
			dt.RowChanged += new DataRowChangeEventHandler(Row_Changed);
			ModifiedRowsList = new List<DataRow>();
		}
        public void UndoChanges()
        {
            if (ModifiedRowsList.Count > 0)
            {
                DataRow dr = dt.Rows[dt.Rows.IndexOf(ModifiedRowsList[ModifiedRowsList.Count - 1])];
                dr.RejectChanges();
                ModifiedRowsList.RemoveAt(ModifiedRowsList.Count - 1);
            }
        }
        private void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            if(e.Action != DataRowAction.Rollback)
            {
                ModifiedRowsList.Add(e.Row);
            }          
        }
