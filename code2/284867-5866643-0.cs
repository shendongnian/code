SqlDataReader rdr = null;
SqlConnection conn = new SqlConnection("Data Source=Silverage-6\\SQLSERVER2005;Initial Catalog=emp;Integrated Security=SSPI");
try
{
   conn.Open();
   SqlCommand cmd=new SqlCommand ();
   cmd.CommandText="insert into timeday(project,iteration,activity,description,status,hour)values('"+this .name1 .SelectedValue +"','"+this .iteration .SelectedValue +"','"+this .activity .SelectedValue +"','"+this.name2.Text+"','"+this.status .SelectedValue +"','"+this .Text1 .Text +"')";
   cmd.Connection=conn;
   int i=cmd.ExecuteNonQuery();
   if(i>0)
   {
      cmd.CommandText="Select * from timeday";
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
         Console.WriteLine(rdr[0]);
      }
   }
}
finally
{
   if (rdr != null)
      rdr.Close();
   if (conn != null)
      conn.Close();
}
