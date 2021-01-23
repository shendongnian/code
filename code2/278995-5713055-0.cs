    public void UserMsgBox(string sMsg)
    {
	StringBuilder sb = new StringBuilder();
	System.Web.UI.Control oFormObject = null;
	sMsg = sMsg.Replace("'", "\\'");
	sMsg = sMsg.Replace(Strings.Chr(34), "\\" + Strings.Chr(34));
	sMsg = sMsg.Replace(Constants.vbCrLf, "\\n");
	sMsg = "<script language='javascript'>alert(\"" + sMsg + "\")</script>";
	sb = new StringBuilder();
	sb.Append(sMsg);
	foreach (System.Web.UI.Control oFormObject_loopVariable in this.Controls) {
		oFormObject = oFormObject_loopVariable;
		if (oFormObject is HtmlForm) {
			break; // TODO: might not be correct. Was : Exit For
		}
	}
	oFormObject.Controls.AddAt(oFormObject.Controls.Count, new LiteralControl(sb.ToString()));
    }
