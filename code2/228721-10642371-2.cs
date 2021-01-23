        private void BindApprovalsTab()
        {
            uddApproverList.BeforeDropDown -= new CancelEventHandler(uddApproverList_BeforeDropDown);
            uddApproverList.DataSource = dsFindingDetails.Tables["Approvers"];
            uddApproverList.DisplayMember = "fldDisplayName";
            uddApproverList.ValueMember = "fldRoleGID";
            uddApproverList.Width = 150;
            uddApproverList.DisplayLayout.Bands[0].Columns["fldRoleGID"].Hidden = true;
            uddApproverList.DisplayLayout.Bands[0].Columns["fldDisplayName"].Header.Caption = "Role";
            uddApproverList.DisplayLayout.Bands[0].Columns["fldDisplayName"].Width = uddApproverList.Width;
            uddApproverList.BeforeDropDown += new CancelEventHandler(uddApproverList_BeforeDropDown);
            ugActionItemApprovals.DataSource = dsFindingDetails.Tables["tblIssueApprovals"];
        }
        void uddApproverList_BeforeDropDown(object sender, CancelEventArgs e)
        {
            //assume all rows show
            foreach (UltraGridRow udr in uddApproverList.Rows)
            {
                udr.Hidden = false;
            }
            //can we remove already used entries?
            foreach (UltraGridRow udr in uddApproverList.Rows)
            {
                string sDDRoleGID = udr.Cells["fldRoleGID"].Value.ToString();
                foreach (UltraGridRow ur in ugActionItemApprovals.Rows)
                {
                    if (ur.Cells["fldApprovalRequiredBy"].Value.ToString() == sDDRoleGID)
                    {
                        udr.Hidden = true;
                        break;
                    }
                }
            }
        }
