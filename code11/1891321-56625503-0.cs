    var cnt = _findRelated("txtDynamic") + 1; //for all the dynamic text boxes i am using the prefix of txtDynamic just to keep SOC.
    var nId = $"txtDynamic-{cnt}";
    
    var _ctrl = new HtmlInputText("Integer")
    {
        Name = nId,
        ID = nId,
        //Value="Default Value" //uncomment to assign a default value
    };
    _ctrl.Attributes.Add("runat", "server");
    var row = new System.Web.UI.HtmlControls.HtmlTableRow();
    var newCell = new HtmlTableCell();
    newCell.Controls.Add(_ctrl);
    row.Cells.Add(newCell);
    my_Table.Rows.Add(row);
    Session.Add(cnt.ToString(), _ctrl); //here i am using session to manage the controls but you can also use the ViewState
