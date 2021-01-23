        // Added a ViewState persisted prop
        bool WireUpControls
        {
            get
            {
                return ViewState["wireUpControls"] != null ? Convert.ToBoolean(ViewState["wireUpControls"]) : false;
            }
            set
            {
                ViewState["wireUpControls"] = value;
            }
        }
        void CreateControlTable()
        {
            int cellIx = 0, rowIx = 0;
            HtmlTableRow tr1 = new HtmlTableRow();
            HtmlTableCell td11 = new HtmlTableCell();
            tr1.Cells.Add(td11);
            HtmlTableCell td12 = new HtmlTableCell();
            td12.InnerText = "td12";
            tr1.Cells.Add(td12);
            HtmlTableRow tr2 = new HtmlTableRow();
            HtmlTableCell td21 = new HtmlTableCell();
            tr2.Cells.Add(td21);
            HtmlTableCell td22 = new HtmlTableCell();
            tr2.Cells.Add(td22);
            td22.InnerText = "td22";
            HtmlTableRow[] arrRows = new HtmlTableRow[2];
            arrRows[rowIx++] = tr1;
            arrRows[rowIx++] = tr2;
            HtmlTableCell[] arrCells = new HtmlTableCell[4];
            arrCells[cellIx++] = td11;
            arrCells[cellIx++] = td12;
            arrCells[cellIx++] = td21;
            arrCells[cellIx++] = td22;
            ControlInfo ci = PersistControl("tblResult", "HtmlTable", 3, arrRows, arrCells, 2, 2);
            HtmlTable tblResult = (HtmlTable)CreateControl(ci);
            ci = PersistControl("btnEdit1", "Button", 0, arrRows, arrCells, 2, 2);
            Button btnEdit1 = (Button)CreateControl(ci);
            ci = PersistControl("btnEdit2", "Button", 0, arrRows, arrCells, 2, 2);
            Button btnEdit2 = (Button)CreateControl(ci);
        }
        // Call CreateControlTable() if we need to create the controls and wire up events
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCreateTbl.Click += new EventHandler(BtnClick);
            if (WireUpControls) CreateControlTable();
            //if (this.IsPostBack) this.RecreatePersistedControls();
            
        }
        protected void BtnClick(object sender, EventArgs e)
        {
           WireUpControls = true;
           CreateControlTable();
        }
        public void DoNothing(object sender, EventArgs e)
        {
            lblResult.Text = (sender as Button).ID + " done";
        }
