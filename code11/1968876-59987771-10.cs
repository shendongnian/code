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
    var DataList = new List<dynamic>();
    while (dr.Read())
    {
                    
        var myObj = new Dictionary<string, string>();
                    
        myObj["Id"] = dr["Id"].ToString();
        myObj["Name"] = dr["Name"].ToString();
        myObj["Age"] = dr["Age"].ToString();
        myObj["Location"] = dr["Location"].ToString();
        myObj["Sex"] = dr["Sex"].ToString();
                    
        DataList.Add(myObj); // Add dictionary as an object to List.
    }
}
****
>Deserialization
You can use the following to deserialize the objects and read their properties.
**ExpandoObject or Dictionary**
public ActionResult EmpList()
{
    DBService service = new DBService();
    ViewModel data = new ViewModel();
    // Just to make sure its a string
    string strdata = service.getData();
    data.EmployeeDataList = JsonConvert.DeserializeObject<List<Employee>>(strData).ToList();
    return View(data);
}
*****
#Update
Test Case using loops.
var DataList = new List<dynamic>();
List<Employee> EmployeeDataList = new List<Employee>();
for (int i = 0; i < 4; i++)
{
    var myObj = new Dictionary<string, string>();
    myObj["Id"] = i.ToString();
    myObj["Name"] = "Name" + i.ToString();
    myObj["Age"] = "Age" + i.ToString();
    myObj["Location"] = "Location" + i.ToString();
    myObj["Sex"] = "Sex" + i.ToString();
    DataList.Add(myObj); // Add Dictionary to List.
}
for (int i = 0; i < 4; i++)
{
    dynamic myObj = new ExpandoObject();
    myObj.Id = i.ToString();
    myObj.Name = "Name" + i.ToString();
    myObj.Age = "Age" + i.ToString();
    myObj.Location = "Location" + i.ToString();
    myObj.Sex = "Sex" + i.ToString();
    DataList.Add(myObj); // Add Expando Object to List
}
// Represents the data you will recieve from service.getData();
string strData = JsonConvert.SerializeObject(DataList);
// represents the list of Employee.
EmployeeDataList = JsonConvert.DeserializeObject<List<Employee>>(strData).ToList();
