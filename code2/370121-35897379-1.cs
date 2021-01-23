    public class Person
    {
    	public int EmpID { get; set; }
    	public string Name { get; set; }
    	public string Department { get; set; }
    	public string Gender { get; set; }
    }
    
    void Main()
    {	
    	Dictionary<int, Person> EmployeeList = new Dictionary<int, Person>();
    	EmployeeList.Add(1, new Person() {EmpID = 1, Name = "Peter", Department = "Development",Gender = "Male"});
    	EmployeeList.Add(2, new Person() {EmpID = 2, Name = "Emma Watson", Department = "Development",Gender = "Female"});
    	EmployeeList.Add(3, new Person() {EmpID = 3, Name = "Raj", Department = "Development",Gender = "Male"});
    	EmployeeList.Add(4, new Person() {EmpID = 4, Name = "Kaliya", Department = "Development",Gender = "Male"});
    	EmployeeList.Add(5, new Person() {EmpID = 5, Name = "Keerthi", Department = "Development",Gender = "Female"});
    	
        List<int> eid = new List<int>() { 1,3 };
    
    	List<Person> SelectedEmployeeList = new List<Person>();
    	
    	var temp = eid.Select(i => 
    				EmployeeList.ContainsKey(i) 
    				? EmployeeList[i]
    				: null
    			).Where(i => i != null).ToList();
    	
    }
