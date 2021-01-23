    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    
    namespace WebApplication1
    {
        [ServiceContract]
        public interface ITestService
        {
            [OperationContract]
            [WebGet(ResponseFormat = WebMessageFormat.Json)]
            List<Person> GetResults();
        }
    
        public class TestService : ITestService
        {
            public List<Person> GetResults()
            {
                List<Person> results = new List<Person>();
                results.Add(new Person("Peyton", "Manning", 35));
                results.Add(new Person("Drew", "Brees", 31));
                results.Add(new Person("Tony", "Romo", 29));
    
                return results;
            }
        }
    
        [DataContract]
        public class Person
        {
            [DataMember]
            public string FirstName { get; set; }
    
            [DataMember]
            public string LastName { get; set; }
    
            [DataMember]
            public int Age { get; set; }
    
            public Person(string firstName, string lastName, int age)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Age = age;
            }
        }
    }
