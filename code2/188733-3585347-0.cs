        protected void Page_Load(object sender, EventArgs e)
            {
                if(!IsPostBack)
                    SetTabGrids(();
            }
            protected void btnPrint_Click(object sender, EventArgs e)
            {
                //Code
                SetTabGrids();
            }
            protected void tabconConsignments_TabIndexChanged(object sender, EventArgs e)
            {
                //Code
                SetTabGrids();
            }
        
            private void SetTabGrids()
            {
                switch(tabconConsignments.ActiveTabIndex)
                    case 0: //Global ID Tab
                        dtGlobalIDConsignments = fGenerateTableSQL(astrPalletIDs, DateFrom, DateTo, ddlReqColDel.SelectedValue, "GlobalID", "", "");
                        gvGlobal.DataSource = dtGlobalIDConsignments;
                        gvGlobal.DataBind();
                        AddActionsToGridView(gvGlobal);
                        AddCheckboxesToGridView(gvGlobal);
                        break;
                    case 1: //Created Date Tab
                        dtCreatedDateConsignments = fGenerateTableSQL(astrPalletIDs, DateFrom, DateTo, ddlReqColDel.SelectedValue, "CreatedDate", "", "");
                        gvCreationDate.DataSource = dtCreatedDateConsignments;
                        gvCreationDate.DataBind();
                        tbCreationDateSearch.Text = "";
                        AddActionsToGridView(gvCreationDate);
                        AddCheckboxesToGridView(gvCreationDate);
                        break;
                    case 2:
                        dtAccountsConsignments = fGenerateTableSQL(astrPalletIDs, DateFrom, DateTo, ddlReqColDel.SelectedValue, "Account", "", "");
                        gvAccount.DataSource = dtAccountsConsignments;
                        gvAccount.DataBind();
                        AddActionsToGridView(gvAccount);
                        AddCheckboxesToGridView(gvAccount);
                        break;
                } 
            }
