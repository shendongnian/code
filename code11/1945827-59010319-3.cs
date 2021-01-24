    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' the hidden value will be used to uniquely name the cookie and
            ' will be used both on the server and the client side to
            ' work with the cookie.
            windowid.Value = Guid.NewGuid().ToString()
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        ' for demo purposes only
        System.Threading.Thread.Sleep(4000)
        GetCsv()
    End Sub
    Protected Sub GetCsv()
        ' ... 
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(sb.ToString())
        Response.Clear()
        Response.Cookies.Add(New HttpCookie(windowid.Value, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss:ff")))
        Response.AddHeader("Content-Disposition", "attachment; filename=contacts.csv")
        Response.AddHeader("Content-Length", bytes.Length.ToString())
        Response.ContentType = "text/csv"
        Response.Write(sb.ToString())
        Response.Flush()
        Response.End()
    End Sub
