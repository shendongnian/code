    //dt is DataTable
    dt.PrimaryKey = new DataColumn[1] { dt.Columns[0] };  // set your primary key
    DataRow dRow = dt.Rows.Find(SearchTextbox.Text);
    if (dRow != null){
         // you've found it
    }
    else{
        //sorry dude
    }
