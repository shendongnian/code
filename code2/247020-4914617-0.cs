    SqlParameter managerParameter = new SqlParameter("@manager_id", SqlDbType.Int);
    cmd2.Parameters.Add(managerParameter);
    managerParameter.Value = project_manager.SelectedValue;
    SqlParameter memberParameter = new SqlParameter("@member_id", SqlDbType.Int);
    cmd2.Parameters.Add(memberParameter);
    cmd2.CommandType = CommandType.Text;
    // For better performance in the loop, you could prepare the query:
    cmd2.Prepare();
    for (int i = 0; i < project_members.Items.Count; ++i)
    {
        if (project_members.Items[i].Selected)
        {
            memberParameter = project_members.Items[i].Value;
            cmd2.ExecuteNonQuery();
        }
    }
