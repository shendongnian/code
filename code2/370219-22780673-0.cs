    class StudentComparer : IComparer<Student>
    {
        private readonly string _memberName = string.Empty; // the member name to be sorted
        private readonly SortOrder _sortOrder = SortOrder.None;
    
        public StudentComparer(string memberName, SortOrder sortingOrder)
        {
            _memberName = memberName;
            _sortOrder = sortingOrder;
        }
    
    	public int Compare(student student1, student student2)
    	{
    		if (_sortOrder != SortOrder.Ascending)
    		{
    			var tmp = student1;
    			student1 = student2;
    			student2 = tmp;
    		}
    
    		switch (_memberName)
    		{
    			case "Name":
    				return student1.Name.CompareTo(student2.Name);
    			case "Sex":
    				return student1.Sex.CompareTo(student2.Sex);
    			default:
    				return student1.Name.CompareTo(student2.Name);
    		}
    	}
    }
//
    
    private void dgwOrders_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
    	DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
    	
    	string columnName = column.Name;
    
    	SortOrder sortOrder = column.HeaderCell.SortGlyphDirection == SortOrder.Ascending
    							  ? SortOrder.Descending
    							  : SortOrder.Ascending;
    	
    	students.Sort(new StudentComparer(columnName, sortOrder));
    	
    	dataGridView1.Refresh();
    	
    	column.HeaderCell.SortGlyphDirection = sortOrder;
    }
