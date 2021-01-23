    [DataContract]
    public class EmployeeDTO {
    
    public EmployeeDTO(string empName,bool isActive){
       EmployeeName = empName;
       IsActive = isActive;
    }
    [DataMember]
    public string EmployeeName {get;private set;}
    [DataMember]
    public bool IsActive {get;private set;}
    
    }
