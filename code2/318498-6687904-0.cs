    if(Application.Context.CurrentHandler is System.Web.UI.Page
                        && Application.Request["HTTP_X_MICROSOFTAJAX"] == null
                        && Application.Request.Params["_TSM_CombinedScripts_"] == null)
    {
    response.Filter=new PageFilter(response.Filter);
    }
