    Imports System.Data.SqlClient
    Imports System.Data
    
    Partial Class PageInitTest
        Inherits System.Web.UI.Page
    
        Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    
            If Not IsPostBack Then
    
                Dim conn As New SqlConnection("myconnectionstring")
                Dim command As New SqlCommand("mySQL", conn)
                Dim da As New SqlDataAdapter(command)
                Dim tblData As New DataTable
                da.Fill(tblData)
    
                ' now the sorting
                Dim dv As New DataView(tblData)
    
                ' you can also do filtering to not show all of them
                'dv.RowFilter = "MyField = 1"
    
                dv.Sort = "MyField ASC"    ' ASC or DESC
    
                ' then bind the control to the DataView, not the DataTable
                dgdMyData.DataSource = dv
                dgdMyData.DataBind()
    
                conn.Close()
    
            End If
    
        End Sub
    
    End Class
