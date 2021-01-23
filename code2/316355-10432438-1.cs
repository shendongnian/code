        Protected Sub Page_Load(sender As Object, e As EventArgs)
            Me.countMe()
            Dim tmpDs As New DataSet()
            tmpDs.ReadXml(Server.MapPath("~/counter.xml"))
            lblCounter.Text = tmpDs.Tables(0).Rows(0)("hits").ToString()
        End Sub
        Private Sub countMe()
            Dim tmpDs As New DataSet()
            tmpDs.ReadXml(Server.MapPath("~/counter.xml"))
            Dim hits As Integer = Int32.Parse(tmpDs.Tables(0).Rows(0)("hits").ToString())
            hits += 1
            tmpDs.Tables(0).Rows(0)("hits") = hits.ToString()
            tmpDs.WriteXml(Server.MapPath("~/counter.xml"))
        End Sub
