    Response.Buffer = true;//left unmodified, but why were you buffering?
    Response.ContentType = "application/vnd.ms-excel";
    string FileName = "PoliciesDetailsForBranch";
    Response.AppendHeader("content-disposition", "attachment; filename=" + FileName + ".xls");
    GridView gv = new GridView();
    this.EnableViewState = false;
    gv.DataSource = (DataTable)dt;
    gv.DataBind();
    this.ClearControls(gv);
    gv.RenderControl(Response.Output);
    Response.End();
