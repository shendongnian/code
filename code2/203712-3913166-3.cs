    Imports System
    Imports System.Data
    Imports System.Math
    Imports Microsoft.SqlServer.Dts.Runtime
    Imports System.Data.SqlClient.SqlConnection
    Imports Windows.Forms.MessageBox
    
    Public Class ScriptMain
    
    	
    
    	Public Sub Main()
    		'
            ' Add your code here
    
            Dim oCnn As New Data.SqlClient.SqlConnection
            Dim sSQL As String
            Dim sSQL2 As String
            Dim resultOne As Integer
            Dim resultTwo As Integer
            Dim messageBox As Windows.Forms.MessageBox
    
            resultOne = 0
            resultTwo = 0
    
            oCnn.ConnectionString = "Server=ServerName;Database=DatabaseName;Trusted_Connection=true"
            sSQL = "INSERT INTO TestTable(SomeNumericData) VALUES(666) "
            sSQL2 = "SELECT SCOPE_IDENTITY()"
            Dim oCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(sSQL, oCnn)
            Dim oCmd2 As SqlClient.SqlCommand = New SqlClient.SqlCommand(sSQL2, oCnn)
    
            oCmd.CommandType = CommandType.Text
            oCmd.Connection = oCnn
            oCnn.Open()
    
            resultOne = oCmd.ExecuteNonQuery()
            resultTwo = Convert.ToInt32(oCmd2.ExecuteScalar())
    
            oCnn.Close()
    
            messageBox.Show("result1:" + resultOne.ToString + Environment.NewLine + "result2: " + resultTwo.ToString)
    
            Dts.TaskResult = Dts.Results.Success
        End Sub
    End Class
