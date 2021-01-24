        internal string RenderList()
                {
                    ConstructGrid();
                    SetSort();
                
                    var page = new Page() { EnableViewState = false };
                    var form = new System.Web.UI.HtmlControls.HtmlForm();
                    page.Controls.Add(form);
                    if (Data != null && Data.PageInfo != null && Data.PageInfo.TotalRecords > 0)
            {
          form.Controls.Add(this);
           DataBind();
             }
            else
                   var noResultsControl  =  (Page.LoadControl("~/Controls/Shared/NoResults.ascx") as NoResults)  
    noResultsControl.PropertyOne =  "Sample"  ;
        form.Controls.Add(noResultsControl);
          return ControlLoader.RenderCustomControl(page);
                }
