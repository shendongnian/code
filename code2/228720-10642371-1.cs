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
