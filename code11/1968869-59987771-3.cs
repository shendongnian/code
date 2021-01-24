try
{
    conn.Open();
    SqlCommand cmd = new SqlCommand(sql, conn);
    SqlDataReader dr = cmd.ExecuteReader();
    
    while (dr.Read())
    {
        dynamic myObj = new ExpandoObject();
                    
        myObj.Id = dr["Id"].ToString();
        myObj.Name = dr["Name"].ToString();
        myObj.Age = dr["Age"].ToString();
        myObj.Location = dr["Location"].ToString();
        myObj.Sex = dr["Sex"].ToString();
                    
        DataList.Add(JsonConvert.SerializeObject(myObj));
    }
}
**Dictionary**
If you are not comfortable using ExpandoObject, perhaps a dictionary would suffice.
try
{
    conn.Open();
    SqlCommand cmd = new SqlCommand(sql, conn);
    SqlDataReader dr = cmd.ExecuteReader();
    var DataList = new List<string>();
    while (dr.Read())
    {
                    
        var myObj = new Dictionary<string, string>();
                    
        myObj["Id"] = dr["Id"].ToString();
        myObj["Name"] = dr["Name"].ToString();
        myObj["Age"] = dr["Age"].ToString();
        myObj["Location"] = dr["Location"].ToString();
        myObj["Sex"] = dr["Sex"].ToString();
                    
        DataList.Add(JsonConvert.SerializeObject(myObj));
    }
}
****
Deserialization
You can use the following to deserialize the objects and read their properties.
**ExpandoObject**
public ActionResult EmpList()
{
    DBService service = new DBService();
    ViewModel data = new ViewModel();
    data.EmployeeDataList = JsonConvert.DeserializeObject<List<dynamic>>(JsonConvert.SerializeObject(service.getData())).Cast<Employee>().ToList(); ;
    return View(data);
}
