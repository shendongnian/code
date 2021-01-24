using System;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            TestConnection();
        }
        private void TestConnection()
        {
            string connectionString = null;
            SqlConnection cnn;
            SqlConnectionStringBuilder cnBuild = new SqlConnectionStringBuilder();
            cnBuild.DataSource = "Server";
            cnBuild.InitialCatalog = "databaseName";
            cnBuild.UserID = "userid";
            cnBuild.Password = "password";
            // connectionString = "Driver={SQL Server Native Client 11.0};Server=********;Database=********;Uid=********;Pwd=********;"
            cnn = new SqlConnection(cnBuild.ConnectionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception __unusedException1__)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
**VB.Net Code**
Imports System
Imports System.Windows.Forms
Imports System.Data.SqlClient
Namespace WindowsFormsApplication2
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			TestConnection()
		End Sub
		Private Sub TestConnection()
			Dim connectionString As String = Nothing
			Dim cnn As SqlConnection
			Dim cnBuild As New SqlConnectionStringBuilder
			cnBuild.DataSource = "Server"
			cnBuild.InitialCatalog = "databaseName"
			cnBuild.UserID = "userid"
			cnBuild.Password = "password"
			cnn = New SqlConnection(cnBuild.ConnectionString)
			Try
				cnn.Open()
				MessageBox.Show("Connection Open ! ")
				cnn.Close()
			Catch __unusedException1__ As Exception
				MessageBox.Show("Can not open connection ! ")
			End Try
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub
	End Class
End Namespace
  [1]: http://converter.telerik.com/
