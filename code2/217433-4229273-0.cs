        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        
        
        namespace MyExample
        {
            public class MyDeleteButtonField : ButtonField
            {
                private string _ConfirmText = "Delete this record?";
                public string ConfirmText
                {
                    get { return _ConfirmText; }
                    set { _ConfirmText = value; }
        
                }
        
                public override bool Initialize(bool sortingEnabled, Control control)
                {
                    this.CommandName = "Delete";
                    this.ImageUrl = "~/Assets/Images/Buttons/flip.png";
                    this.ButtonType = System.Web.UI.WebControls.ButtonType.Image;
                    return base.Initialize(sortingEnabled, control);
                }
        
                public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
                {
                    base.InitializeCell(cell, cellType, rowState, rowIndex);
                    if (cellType == DataControlCellType.DataCell)
                    {
                        WebControl button = (WebControl)cell.Controls[0];
                        button.Attributes["onclick"] = String.Format("return confirm('{0}');", _ConfirmText);
                    }
                }
        
            }
        }
