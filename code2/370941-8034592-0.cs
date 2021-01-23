        using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication2
    {
    
        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public Department Department { get; set; }
        }
        public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Employee Manager { get; set; }
        }
    
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                String filepath = @"C:\\rrrr.xml";
    
                #region Create Test Data
                List<Employee> list = new List<Employee>();
                for (int i = 0; i < 5; i++)
                {
                    list.Add(new Employee
                                 {
                                     Department = new Department
                                                      {
                                                          Description = "bla bla description " + i,
                                                          Id = i,
                                                          Manager = null,
                                                          Name = "bla bla name " + i
                                                      },
                                     FirstName = "First name " + i,
                                     Id = i + i,
                                     LastName = "Last name " + i,
                                     PhoneNumber = Guid.NewGuid().ToString()
                                 });
                } 
                #endregion
    
                #region Save XML
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                using (Stream fs = new FileStream(filepath, FileMode.Create))
                {
                    using (XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode))
                    {
                        serializer.Serialize(writer, list);
                    }
                } 
                #endregion
    
    
                //Read from XML
    
                XmlDocument doc = new XmlDocument();
                doc.Load(filepath);
    
                List<Employee> newList = new List<Employee>();
                foreach (XmlNode node in doc.GetElementsByTagName("Employee"))
                {
                    Employee ee = GetEmploee(node);
                    newList.Add(ee);
                }
                
                //ta da
            }
    
            public static Employee GetEmploee(XmlNode node)
            {
                return node == null
                           ? new Employee()
                           : new Employee
                                 {
                                     Department = GetDepartment(node["Department"]),
                                     FirstName = (node["FirstName"]).InnerText,
                                     LastName = (node["LastName"]).InnerText,
                                     Id = Convert.ToInt32((node["Id"]).InnerText),
                                     PhoneNumber = (node["PhoneNumber"]).InnerText
                                 };
            }
    
            public static Department GetDepartment(XmlNode node)
            {
                return node == null
                           ? new Department()
                           : new Department
                                 {
                                     Description = node["Description"].InnerText,
                                     Id = Convert.ToInt32(node["Id"].InnerText),
                                     Manager = GetEmploee(node["Manager"]),
                                     Name = node["Name"].InnerText
                                 };
            }
        }
    }
