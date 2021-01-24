    [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public static List<EduDesc> BINDEducationDATA(string iEduid)
    {
        List<EduDesc> details = new List<EduDesc>();
        DataTable dtManager = new DataTable();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("Select Edu_Stream,Edu_Description from tbl_education WHERE ID='" + iEduid + "'", con);
            da.SelectCommand = cmd;
            da.Fill(dtManager);
        }
        foreach (DataRow dtrow in dtManager.Rows)
        {
            EduDesc logs = new EduDesc();
            logs.Edu_desc = (dtrow["Edu_Description"].ToString());
            logs.eduStream = dtrow["Edu_Stream"].ToString();
            details.Add(logs);
        }
        return JsonConvert.SerializeObject(details);
    }
