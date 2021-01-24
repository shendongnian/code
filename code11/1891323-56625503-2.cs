    private void _renderControls()
    {
        try
        {
            if (Session.Count > 0)
            {
                for (int k = 0; k < Session.Count; k++)
                {
                   if (Session[k] != null)
                   {
                        var _ctrl = new HtmlInputText("Integer") //you can make it dynamic to add different types of input control
                        {
                            Name = ((HtmlInputText)Session[k]).ID,
                            ID = ((HtmlInputText)Session[k]).ID,
                            Value = ((HtmlInputText)Session[k]).Value
                        };
                        if (_ctrl != null)
                        {
                            _ctrl.Attributes.Add("runat", "server");
                            var row = new System.Web.UI.HtmlControls.HtmlTableRow();
                            var newCell = new HtmlTableCell();
                            newCell.Controls.Add(_ctrl);
                            row.Cells.Add(newCell);
                            my_Table.Rows.Add(row);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
