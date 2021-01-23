        if (e.CommandName == "Details")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("~/MEMBER/UploadedDocList.aspx?id=" + id, false);
        }
    }
