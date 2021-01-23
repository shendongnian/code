    string url = "Detailscherm.aspx?"
            + "melder=" + HttpUtility.UrlEncode(gv.SelectedRow.Cells[1].Text)
            + "&onderwerp=" + HttpUtility.UrlEncode(gv.SelectedRow.Cells[2].Text)
            + "&omschrijving=" + HttpUtility.UrlEncode(lblOmschrijving.Text)
            + "&fasedatum=" + HttpUtility.UrlEncode(gv.SelectedRow.Cells[4].Text)
            + "&outlookid=" + HttpUtility.UrlEncode(lblOutlookID.Text)
            + "&status=" + HttpUtility.UrlEncode(status)
            + "&niv1=" + HttpUtility.UrlEncode("")
            + "&niv2=" + HttpUtility.UrlEncode("");
    Response.Redirect(url);
