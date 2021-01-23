    protected void gvAgendamentoExclui_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                LinkButton lnk = e.Row.FindControl("LinkButton2") as LinkButton;
                AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = lnk.UniqueID;
                trigger.EventName = "Click";
                UpdatePanel2.Triggers.Add(trigger);
            
            }
        }
