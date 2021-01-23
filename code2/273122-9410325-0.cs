    Dim dt As DataTable = ViewState("FinalState")
	Dim GV As New GridView
	GV.DataSource = dt ' UpdateDataTable(ViewState("FinalTable"))
	GV.DataBind()
	Response.Clear()
	Response.Buffer = True
	Response.AddHeader("content-disposition", "attachment;filename=ProspectsBank.xls")
	Response.Charset = ""
	Response.ContentType = "application/vnd.ms-excel"
	Dim sw As New StringWriter()
	Dim hw As New HtmlTextWriter(sw)
	For i As Integer = 0 To GV.Rows.Count - 1
		'Apply text style to each Row 
		GV.Rows(i).Attributes.Add("class", "textmode")
	Next
	GV.RenderControl(hw)
	Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
	Response.Write(style)
	Response.Output.Write(sw.ToString())
	clsLog.SaveLogValue(Request.ServerVariables("REMOTE_ADDR"), "SearchAudienceForMagazine.aspx", "User Export Data From Our Databank in EXCEL format. Current they Exported " & dt.Rows.Count & " Data.", Session("User_TypeId"), Session("User_Name"))
	Response.Flush()
	Response.End()
