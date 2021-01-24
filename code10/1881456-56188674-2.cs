c#
using (DataContext ctx = DataContext())
{
    int result = ctx.SP_ProcedureName("1", "2", "3");
}
But first you have to add it to DataContext Diagram from your database as you add tables but from "Stored Procedures" folder.
that is more defensive and neat solution. but if you prefer to use raw command line at least use parameterized query for it like this example :
    string sqlText = "SELECT columnName FROM Test_Attachments WHERE Project_Id =@PID1 AND [Directory] = @Directory";
     SqlCommand myCommand = new SqlCommand(sqlText, SqlConnection);
     myCommand.Parameters.AddWithValue("@PID1", 12);
     myCommand.Parameters.AddwithValue("@Directory", "testPath");
It is way for avoiding SQL injection to your code.
Also you could use finally block for close connection :
   
        finally
        {
            command.Connection.Close();
        }
