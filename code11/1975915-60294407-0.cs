using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace XMLSerialization
{  
    [XmlRoot("CompanyEmployees")]
    public class EmployeeList
    {
        [XmlArray("EmployeeListing")]
        [XmlArrayItem("Employee", typeof(Employee))]
        public List employeeList;
        // Constructor
        public EmployeeList()
        {
            employeeList = new List();
        }
        public void AddEmployee(Employee employee)
        {
            employeeList.Add(employee);
        }
    }
}
And actual serialization 
private void SerializeList()
{
    // Create an instance of the EmployeeList class
    EmployeeList employeeList = new EmployeeList();
    // Create a few instances of the Employee class
    Employee emp1 = new Employee();
    emp1.Name = "John";
    emp1.Surname = "Smith";
    emp1.DateOfBirth = new DateTime(1980, 10, 08);
    emp1.Sex = Employee.EmployeeSex.Male;
    emp1.Position = "Software Engineer";
    Employee emp2 = new Employee();
    emp2.Name = "David";
    emp2.Surname = "McGregor";
    emp2.DateOfBirth = new DateTime(1973, 01, 13);
    emp2.Sex = Employee.EmployeeSex.Male;
    emp2.Position = "Product Manager";
    Employee emp3 = new Employee();
    emp3.Name = "Sarah";
    emp3.Surname = "Crow";
    emp3.DateOfBirth = new DateTime(1983, 11, 23);
    emp3.Sex = Employee.EmployeeSex.Female;
    emp3.Position = "Software Tester";
    // Add the employees to the list   
    employeeList.AddEmployee(emp1);
    employeeList.AddEmployee(emp2);
    employeeList.AddEmployee(emp3);
    // Create an instance of System.Xml.Serialization.XmlSerializer
    XmlSerializer serializer = new XmlSerializer(employeeList.GetType());
    // Create an instance of System.IO.TextWriter 
    // to save the serialized object to disk
    TextWriter textWriter = new StreamWriter("C:\\Employee\\employeeList.xml");
    // Serialize the employeeList object
    serializer.Serialize(textWriter, employeeList);
    // Close the TextWriter
    textWriter.Close();
}
