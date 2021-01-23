    // Constructor for retired / unemployed people
    public class EmploymentInformation(EmploymentStatus status) {}
    // Constructor for self-employed people - we know their status
    public class EmploymentInformation(string occupation) {}
    // Constructor for people employed by others - we know their status
    public class EmploymentInformation(string occupation, Company employer) {}
    
    public bool IsEmployed { get; }
    public string Occupation { get; }
    public Company Employer { get; }
