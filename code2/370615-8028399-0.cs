    Imports System.Data.OleDb
    Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim mydb As New OleDbConnection
        mydb =
        New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= |datadirectory|openclinica.mdb;Persist Security Info=True")
        mydb.Open()
        Dim part2 As Integer = Session("Itemcount")
        
        For Each C As Control In PlaceHolder1.Controls
            If TypeOf (C) Is TextBox Then
                Dim sqlstring = "insert into [followup] ([mrn], [fu], [fudata]) values (@mrntxt, @mylabel" + ", @mydata);"
                Dim mydbcommand As New OleDbCommand(sqlstring, mydb)
                mydbcommand.Parameters.Add("@mrntxt", OleDbType.VarChar).Value = MRNtxt.Text
                mydbcommand.Parameters.Add("@mylabel", OleDbType.VarChar).Value = C.ID
                mydbcommand.Parameters.Add("@mydata", OleDbType.VarChar).Value = CType(C, TextBox).Text
                mydbcommand.ExecuteNonQuery()
            End If
        Next
        mydb.Close()
    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitializeCRF()
    End Sub
    Private Sub InitializeCRF()
        Dim CRFgrid As New GridView
        CRFgrid.DataSource = CRFds
        CRFgrid.DataBind()
        Dim ItemCount As Integer = CRFgrid.Rows.Count
        'Response.Write(ItemCount.ToString)
        Session("Itemcount") = CRFgrid.Rows.Count
        For I = 0 To (ItemCount - 1)
            Dim itemname As String = CRFgrid.Rows(0 + I).Cells(1).Text.ToString
            Session("Item") = "Item" + (I + 1).ToString
            Dim ItemNamelabel As New Label
            Dim ItemNameBox As New TextBox
            ItemNameBox.ID = itemname
            ItemNamelabel.Text = "<br/>" & itemname
            PlaceHolder1.Controls.Add(ItemNamelabel)
            PlaceHolder1.Controls.Add(ItemNameBox)
            ' Response.Write(itemname)
            ' Response.Write(", ")
        Next
    End Sub
    End Class
