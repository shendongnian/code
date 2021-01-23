    //...Wrote separate class for calling this function
    FunctionClass obj = new FunctionClass();
    List<Designation> details = new List<Designation>();
    bool result1 = obj.DataDrop(out details);
    if (result1 == true)
    {
    dropDownDesignation.DataSource = details;
    dropDownDesignation.DataTextField = "designation";
    dropDownDesignation.DataValueField = "Designation_ID";
    dropDownDesignation.DataBind();
    dropDownDesignation.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    //..This function wrote inside FunctionClass and called from aspx.cs page
    public bool DataDrop(out List<Designation> designationDetails)
    {
    designationDetails = new List<Designation>();
    conn = new SqlConnection(connectionName);
    conn.Open();
    command.Connection = conn;
    command.CommandType = CommandType.StoredProcedure;
    command.CommandText = "DesignationDetails";
    userReader = command.ExecuteReader();
    if(userReader.HasRows)
    {
        while(userReader.Read())
	{
	    designationDetails.Add(new Designation()
	    {
                designationId=userReader.GetInt32(0),
                designation=userReader.GetString(1)
            });
	 }
    }
    return true;
    }
    //..This should declare outside the class but inside the namespace
    public class Designation
    {
    public int designationId { get; set; }
    public string designation { get; set; }
    }
