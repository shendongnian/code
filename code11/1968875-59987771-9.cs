try
{
    conn.Open();
    SqlCommand cmd = new SqlCommand(sql, conn);
    SqlDataReader dr = cmd.ExecuteReader();
    // Use a list of dynamic variables instead of string.
    var DataList = new List<dynamic>();
    while (dr.Read())
    {
        dynamic myObj = new ExpandoObject();
                    
        myObj.Id = dr["Id"].ToString();
        myObj.Name = dr["Name"].ToString();
        myObj.Age = dr["Age"].ToString();
        myObj.Location = dr["Location"].ToString();
        myObj.Sex = dr["Sex"].ToString();
                    
        DataList.Add(myObj); // Add ExpandoObject as it is without conversion.
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
>Deserialization
You can use the following to deserialize the objects and read their properties.
**ExpandoObject**
public ActionResult EmpList()
{
    DBService service = new DBService();
    ViewModel data = new ViewModel();
    // Just to make sure its a string
    string strdata = service.getData();
    data.EmployeeDataList = JsonConvert.DeserializeObject<List<Employee>>(strData).ToList();
    return View(data);
}
**Dictionary Deserialization**
public ActionResult EmpList()
{
    DBService service = new DBService();
    ViewModel data = new ViewModel();
     string strData = service.getData();
    data.EmployeeDataList = JsonConvert.DeserializeObject<List<dynamic>>(strData)
                            .Select(x => JsonConvert.DeserializeObject<Employee>(x)).ToList();
    return View(data);
}
*****
#Update
**Update to ExpandoObject Serialization and deserialization**
Just finished testing again. 
var DataList = new List<dynamic>();
List<Employee> EmployeeDataList = new List<Employee>();
for (int i = 0; i < 4; i++)
{
    dynamic myObj = new ExpandoObject();
    myObj.Id = i.ToString();
    myObj.Name = "Name" + i.ToString();
    myObj.Age = "Age" + i.ToString();
    myObj.Location  = "Location" + i.ToString();
    myObj.Sex = "Sex" + i.ToString();
    DataList.Add(myObj); // Dont serialize here. Leave it as ExpandoObject.
}
// At this time, you have a List<string> (DataList)
string strData = JsonConvert.SerializeObject(DataList); //String version of the DataList.
EmployeeDataList = JsonConvert.DeserializeObject<List<Employee>>(strData).ToList();
