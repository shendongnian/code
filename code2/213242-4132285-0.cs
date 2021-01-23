    public interface IMyDAO
    {
      void InsertData(int data);
    }
    public class SqlMyDAO : IMyDAO
    {
      public void InsertData(int data) { throw new NotImplementedException(); }
    }
    public class DAOFactory
    {
      public static IMyDAO GetMyDAO() { return new SqlMyDAO(); }
    }
    public class MyForm : Form
    {
      private void Button_Click(object sender, EventArgs e)
      {
        DAOFactory.GetMyDAO().InsertData(123);
      }
    }
