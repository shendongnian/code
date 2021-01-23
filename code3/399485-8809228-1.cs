    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication1
    {
        [DataContract]
        public class NamedIndividual
        {
            #region Fields
            private string firstName;
            private string middleInitial;
            private string lastName;
            #endregion
    
            #region Properties
    
            [DataMember(IsRequired = true)]
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }
    
            [DataMember(IsRequired = false)]
            public string MiddleInitial
            {
                get { return middleInitial; }
                set { middleInitial = value; }
            }
    
            [DataMember(IsRequired = true)]
            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }
            
            #endregion
    
            public NamedIndividual()
            {
    
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                string name = "{'FirstName':'David', 'MiddleInitial':'Q', 'LastName':'Hoerster'}";
                string name1 = "{'FirstName':'David', 'LastName':'Hoerster'}";
    
                var obj = JsonConvert.DeserializeObject<NamedIndividual>(name);
                var obj1 = JsonConvert.DeserializeObject<NamedIndividual>(name1);
    
                Console.WriteLine(obj.MiddleInitial);
                Console.WriteLine("{0} {1} {2}",obj1.FirstName, obj1.MiddleInitial, obj1.LastName);
            }
        }
    }
