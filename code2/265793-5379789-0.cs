Try using Server.Transfer(), or put the variables in session or post a form.
Session["melder"] = Server.UrlEncode(gv.SelectedRow.Cells[1].Text);
Session["onderwerp"] = Server.UrlEncode(gv.SelectedRow.Cells[2].Text);
...
Response.Redirect("Detailscherm.aspx");
