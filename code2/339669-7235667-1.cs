 public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            populatecboAdUsers();
        }
public void populatecboAdUsers()
        {
            List<Employee> oEmployee = manager.getAllEmployees();
            //oEmployee.Sort();//uses the default compare by samAccountName
            IComparer myComparer = new Employee.compareEmployeeByLastName();
            oEmployee.Sort(myComparer.Compare);
            foreach (var x in oEmployee)
            {
            
                cboAdUsers.Items.Add(x.lastname);
                Console.WriteLine(x.lastname);
     
       }
}//end of Form1:form class
//new class below
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace ActiveDirectory
{
    public class Employee :IComparable
    {
        public class compareEmployeeByLastName : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Employee emp1 = (Employee)x;
                Employee emp2 = (Employee)y;
                return String.Compare(emp1.lastname, emp2.lastname);
            }
        }
        //default sort order
        public int CompareTo(object oEmployee)
        {
            Employee emp1 = (Employee)oEmployee;
            return String.Compare(this.samAccountName, emp1.samAccountName);
        }
        public string firstName 
        { 
            get; set; 
        }
        public string lastName
        {
            get;
            set;
            
        }
        public string commonName
        {
            get;
            set;
        }
        public string department
        {
            get;
            set;
        }
        public string distinguishedName
        {
            get;
            set;
        }
        public string employeeID
        {
            get;
            set;
        }
        public string samAccountName
        {
            get;
            set;
        }
        public string email
        {
            get;
            set;
        }
        public string title
        {
            get;
            set;
        }
        public UserPrincipalExtension oUserPrincipalExtension
        {
            get;
            set;
        }
    }
}
