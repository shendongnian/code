        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                const string SUBDIR = "images";
                foreach (string fileName in System.IO.Directory.GetFiles(Server.MapPath(SUBDIR)))
                {
                    var oRow = new HtmlTableRow();
                    var oCell = new HtmlTableCell();
                    var oHREF = new HtmlAnchor();
                    string actualFileName = System.IO.Path.GetFileName(fileName);
                    oHREF.HRef = Request.ApplicationPath + "//" + SUBDIR + "//" + actualFileName;
                    oHREF.InnerText = actualFileName;
                    oCell.Controls.Add(oHREF);
                    oRow.Cells.Add(oCell);
                    tblImages.Rows.Add(oRow);
                }
            }
        }
