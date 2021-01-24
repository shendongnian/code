    public class Department {
        [JsonProperty("departmentNumber ")]
        public int DepartmentNumber {get;set;}
        [JsonProperty("departmentName ")]
        public string DepartmentName {get;set;}
    }
    
    List<Department> departments = JsonConvert.DeserializeObject<List<Department>>(jsonString);
