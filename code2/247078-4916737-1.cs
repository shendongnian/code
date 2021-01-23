    Public Class GridViewDemo
        Inherits System.Web.UI.Page
    
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
               bindSampleData()
            End If
        End Sub
    
        Private Sub bindSampleData()
            Dim rnd As New Random(Date.Now.Millisecond)
            Dim data As New DataTable("SampleData")
            data.Columns.Add("Month", GetType(String))
            data.Columns.Add("Sold", GetType(Double))
            data.Columns.Add("Units", GetType(Int32))
            For m As Int32 = 1 To 12
                Dim row As DataRow = data.NewRow
                row("Month") = Globalization.CultureInfo.CurrentCulture.DateTimeFormat().GetMonthName(m)
                row("Sold") = 1000 * rnd.Next(1, 10) + rnd.Next(0, 999)
                row("Units") = 10 * rnd.Next(1, 10) + rnd.Next(0, 99)
                data.Rows.Add(row)
            Next
    
            Me.GridView1.DataSource = data
            Me.GridView1.DataBind()
        End Sub
    
        Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim month As String = DirectCast(DirectCast(e.Row.DataItem, DataRowView)("Month"), String)
                ' don't allow to edit current month's values to demonstrate how to edit certain rows '
                If month.Equals(Globalization.CultureInfo.CurrentCulture.DateTimeFormat().GetMonthName(Date.Now.Month)) Then
                    e.Row.Cells(0).Enabled = False
                Else
                    e.Row.Cells(0).Enabled = True
                End If
            End If
        End Sub
    
        Private Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
            GridView1.EditIndex = e.NewEditIndex
            bindSampleData()
        End Sub
    
        Private Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
            GridView1.EditIndex = -1
            bindSampleData()
        End Sub
        Private Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
            Dim records(e.NewValues.Count - 1) As DictionaryEntry
            e.NewValues.CopyTo(records, 0)
            ' Iterate through the array and HTML encode all user-provided values 
            ' before updating the data source.
            Dim entry As DictionaryEntry
            For Each entry In records
               e.NewValues(entry.Key) = Server.HtmlEncode(entry.Value.ToString())
            Next
            ' process the changes, f.e. write it to the database, senseless with my random sample-data '
            GridView1.EditIndex = -1
            bindSampleData()
       End Sub
    End Class
