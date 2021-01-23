Just as with all other things: **keep it simple**. If you want to write a DAL yourself, then only write the code you need to perform database operations. public class MyDal
{
  private SqlConnection _connection;
  public MyDal() 
  {
    _connection = new SqlConnection("connection string here");  
  }
  public DataSet GetSomeData()
  {
    // write the code that reads from the database and parses the data in a DataSet
  }
}</pre>Of course, if you want to, there are numerous good solutions that prevent you from having to write your own DAL. Personally, I like Castle ActiveRecord, since it's that simple. You just write your data objects and give them some attributes, and ActiveRecord takes care of all database communication. 
