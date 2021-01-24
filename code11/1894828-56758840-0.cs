class Patient 
{
    public int Age { get; set; }    
    public string Name { get; set; }
}
static void Main(string[] args)
{
    var patients = new List<Patient> {
        new Patient { Age = 24, Name = "John"},
        new Patient { Age = 36, Name = "Johny"},
        new Patient { Age = 24, Name = "Jonas"},
        new Patient { Age = 18, Name = "John"},
    };
    var filters = new Dictionary<string,object>();
    filters.Add("Age", 24);
    filters.Add("Name", "John");
    var query = patients.AsQueryable();
    foreach (var filter in filters)
    {
        query = query.Where(p => p.GetType().GetProperty(filter.Key).GetValue(p, null).ToString() == filter.Value.ToString());
    }
    foreach (var patient in query.ToList())
    {
        System.Console.WriteLine($"Name: {patient.Name}, Age: {patient.Age}");                
    }
    
}
