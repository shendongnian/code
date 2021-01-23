      using System;
      using System.IO;
      using System.Collections;
      using System.Xml.Serialization;
      
      public class Test{
          static void Main(){
              Test t = new Test();
              t.SerializeCollection("coll.xml");
          }
      
          private void SerializeCollection(string filename){
              Employees Emps = new Employees();
              // Note that only the collection is serialized -- not the 
      
              // CollectionName or any other public property of the class.
      
              Emps.CollectionName = "Employees";
              Employee John100 = new Employee("John", "100xxx");
              Emps.Add(John100);
              XmlSerializer x = new XmlSerializer(typeof(Employees));
              TextWriter writer = new StreamWriter(filename);
              x.Serialize(writer, Emps);
          }
      }
      public class Employees:ICollection{
          public string CollectionName;
          private ArrayList empArray = new ArrayList(); 
      
          public Employee this[int index]{
              get{return (Employee) empArray[index];}
          }
          
          public void CopyTo(Array a, int index){
              empArray.CopyTo(a, index);
          }
          public int Count{
              get{return empArray.Count;}
          }
          public object SyncRoot{
              get{return this;}
          }
          public bool IsSynchronized{
              get{return false;}
          }
          public IEnumerator GetEnumerator(){
              return empArray.GetEnumerator();
          }
      
          public void Add(Employee newEmployee){
              empArray.Add(newEmployee);
          }
      }
      
      public class Employee{
          public string EmpName;
          public string EmpID;
          public Employee(){}
          public Employee(string empName, string empID){
              EmpName = empName;
              EmpID = empID;
          }
      }
