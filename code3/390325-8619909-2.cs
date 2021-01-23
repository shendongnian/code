    Public Class MyUserControl
    	Inherits System.Web.UI.UserControl
    
    	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    		Debug.Write("Page_Load of {0}", Me.ID)
    		Dim oStrBldr As New StringBuilder()
    		For i As Integer = 1 To Me.MyInt
    			oStrBldr.AppendFormat("{0}: {1} - {2} at {3}<br />{4}", Me.ID, i, Me.MyString, Date.Now.ToLongTimeString(), System.Environment.NewLine)
    		Next
    		Me.lblTime.Text = oStrBldr.ToString()
    	End Sub
    
    
    	Public Property MyInt As Integer
    	Public Property MyString As String
    
    End Class
