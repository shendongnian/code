    SqlParameter memberParameter = new SqlParameter("@member_id", SqlDbType.Int);
    cmd2.Parameters.Add(memberParameter);
    cmd2.CommandType = CommandType.Text;
    // For better performance in the loop, you could prepare the query:
    cmd2.Prepare();
    memberParameter.Value = project_manager.SelectedValue;
    cmd2.ExecuteNonQuery();
    for (int i = 0; i < project_members.Items.Count; ++i)
    {
        if (project_members.Items[i].Selected)
        {
            memberParameter = project_members.Items[i].Value;
            cmd2.ExecuteNonQuery();
        }
    }
