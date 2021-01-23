        private void frmMain_Load(object sender, EventArgs e)
        {
            List<string> grpList = new List<string>();
            ADSI objADSI = new ADSI();
            grpList = objADSI.fetchGroups();
            foreach (string group in grpList)
            {
                if (group == "SpecificGroupName")
                {
                    chkLst.Items.Add(group, CheckState.Indeterminate);
                    
                }
                else
                {
                    chkLst.Items.Add(group);
                }
                
            }
