    static void Main(string[] args)
    {
        var empInfo = GetEmpInfo();
        Console.WriteLine("Employee Details: {0}, {1}, {2}, {3}", empInfo.firstName, empInfo.lastName, empInfo.computerName, empInfo.Salary);
    }
    
    static (string firstName, string lastName, string computerName, int Salary) GetEmpInfo()
    {
        //This is hardcoded just for the demonstration. Ideally this data might be coming from some DB or web service call
        return ("Rasik", "Bihari", "Rasik-PC", 1000);
    }
