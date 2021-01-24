    public partial class Sheet1
    {
        // assign temp variables for header range and a column name
        // template
        public Excel.Range HeaderRange { get; set; }
        public string template;
    
    
        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            // subscribe to ListObject change event
            list1.Change += new Microsoft.Office.Tools.Excel.ListObjectChangeHandler(list1_Change);
            // get the template on start (switch of events for a while)
            this.Application.EnableEvents = false;
            GetDefaultColumnHeaderTemplate();
            this.Application.EnableEvents = true;
        }
    
        private void Sheet1_Shutdown(object sender, System.EventArgs e)
        {
        }
    
    
        //ListObject change event:
        void list1_Change(Microsoft.Office.Interop.Excel.Range targetRange, Microsoft.Office.Tools.Excel.ListRanges changedRanges)
        {
            // assign variables to simplify the code below
            Excel.Range Intersection = Globals.Sheet1.Application.Intersect((Excel.Range)targetRange, HeaderRange);
            HeaderRange = list1.HeaderRowRange;
    
            // if range is assigned - means that change was done in header row
            if (!(Intersection == null))
            {
                // make sure that changed range is only one cell
                if (Intersection.Rows.Count < 2 && Intersection.Columns.Count < 2)
                {
                    // if this cell contains template - delete entire column 
                    if ((targetRange.Value2).ToString().Contains(template))
                    {
                        targetRange.EntireColumn.Delete();
                    }
                }
            }
        }
    
        private void GetDefaultColumnHeaderTemplate()
        {
            // add a column with default name
            Excel.ListColumn tempColumn = list1.ListColumns.Add();
    
            // re-assign headers range
            HeaderRange = list1.HeaderRowRange;
    
            // catch the name of new column with default name
            // and remove a number  counter
            template = GetTextTemplate(HeaderRange.Cells[1, HeaderRange.Columns.Count].Value2.ToString());
    
            // delete temp column
            tempColumn.Delete();
        }
    
        private string GetTextTemplate(string tx)
        {
            string tmp = null;
    
            // go through each char of default column name and take only letters
            for (int i = 0; i < tx.Length; i++)
            {
                if (!double.TryParse(tx.Substring(i, 1), out _))
                {
                    tmp += tx.Substring(i, 1);
                }
            }
            return tmp;
        }
            #region VSTO Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(this.Sheet1_Startup);
            this.Shutdown += new System.EventHandler(this.Sheet1_Shutdown);
    
        }
    
        #endregion
    
    }
