    private void SelectProjectMembers(int projectId)
    {
        CheckBoxList chkbx = (CheckBoxList)FindControl("project_members");
        // verify if chkbx found
    
        foreach (string memberId in GetMemberIdsFor(projectId))
        {
            ListItem memberItem = chkbx.Items.FindByValue(memberId);
    
            if (memberItem != null)
                memberItem.Selected = true;
        }
    }
    
    private IEnumerable<string> GetMemberIdsFor(int projectId)
    {
        List<string> memberIds = new List<string>();
        string query = String.Format("SELECT MemberID FROM ProjectIterationMember WHERE ProjectIterationID IN (SELECT ProjectIterationID FROM Iterations WHERE ProjectID = '{0}')", projectId);
    
        // using statements will dispose connection, command and reader object automatically
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))
        using (SqlCommand cmd5 = new SqlCommand(query, conn))
        {
            conn.Open();
    
            using (SqlDataReader rdr = cmd5.ExecuteReader())
            {
                while (rdr.Read())
                    memberIds.Add(rdr["MemberID"].ToString());
            }
        }
    
        return memberIds;
    }
