    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.IO;
    
    protected void Page_Load(object sender, EventArgs e)
    {
    HtmlTable dTable = new HtmlTable();
    dTable.CellPadding = 2;
    dTable.CellSpacing = 0;
    dTable.Border = 1;
    dTable.BorderColor = "#cccccc";
    
     
    
    int tRows;
    int tCells;
    
    for (tRows = 0; tRows < 5; tRows++)
    {
        HtmlTableRow dTRow = new HtmlTableRow();
        for (tCells = 0; tCells < 4; tCells++)
        {
            HtmlTableCell dTCell = new HtmlTableCell();
            dTCell.InnerText = "Row:: " + Convert.ToString(tRows + 1) + " Col:: " + Convert.ToString(tCells + 1);
            dTRow.Controls.Add(dTCell);
        }
        dTable.Controls.Add(dTRow);
    }
    
    Panel1.Controls.Add(dTable);
    }
