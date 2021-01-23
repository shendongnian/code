    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.UI.WebControls;
    
    namespace MyProject
    {
        public static class ExtensionGridView
        {
            public static GridView RemoveEmptyColumns(this GridView gv)
            {
                // Make sure there are at least header row
                if (gv.HeaderRow != null)
                {
                    int columnIndex = 0;
    
                    // For each column
                    foreach (DataControlFieldCell clm in gv.HeaderRow.Cells)
                    {
                        bool notAvailable = true;
    
                        // For each row
                        foreach (GridViewRow row in gv.Rows)
                        {
                            string columnData = row.Cells[columnIndex].Text;
                            if (!(string.IsNullOrEmpty(columnData) || columnData =="&nbsp;"))
                            {
                                notAvailable = false;
                                break;
                            }
                        }
    
                        if (notAvailable)
                        {
                            // Hide the target header cell
                            gv.HeaderRow.Cells[columnIndex].Visible = false;
    
                            // Hide the target cell of each row
                            foreach (GridViewRow row in gv.Rows)
                                row.Cells[columnIndex].Visible = false;
                        }
    
                        columnIndex++;
                    }
                }
    
                return gv;
            }
        }
    }
