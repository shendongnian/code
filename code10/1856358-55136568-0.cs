     [MessageContract(WrapperNamespace = "www.message.com")]
    public class Employee
    {
        [MessageBodyMember(Namespace = "www.message.com")]
        public string Id { get; set; }
        [MessageBodyMember(Namespace = "www.message.com")]
        public string Name { get; set; }
        [MessageBodyMember(Namespace = "www.message.com")]
        public string Department { get; set; }
        [MessageBodyMember(Namespace = "www.message.com")]
        public string Grade { get; set; }
    }
    
    [ServiceContract]
    public interface IEmployeeService
    {
       [OperationContract]
        Employee GetEmployee(Employee employee);
    }
     public class EmployeeService : IEmployeeService
    {
        public Employee GetEmployee(Employee employee)
        {
            return employee;
        }
    }
