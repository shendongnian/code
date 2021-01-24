    private void connectDb()
    {
         SqlConnection conn = new SqlConnection("YOUR DATABASE LOCATION/ DATABASE PATH");
         conn.Open(); // initalize your database connection
    
    }
    
    private void searchForStudentName()
    {
       string name;// = your textbox that holds value of students name;
       this.connectDb(); //your connection into database
       SqlCommand cmd = new SqlCommand("Select * from ['YOUR TABLE NAME'] where Name = @Name",conn);
       cmd.parameters.AddWithValue("@Name", name);
       dr= cmd.ExcecuteReader();
    
    
      if(dr.Read())//meaning, the system found the value of the input data/ name
      {
         ListViewItem lvi = new ListViewItem(dr["NAME"].ToString);// name will be displayed in listview control
         listView1.items.add(lvi);
      }else
      {
        //there is no data found
      }
    }
