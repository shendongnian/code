    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace BSearch
    {
        public class Person
        {
            public string name;
            public int age;
            private string gender;
            private bool isPersonStateValid;
    
    
            public Person(string _name, int _age, string _gender)
            {
                isPersonStateValid = true;
                this.name = _name;
                this.age = _age;
                this.Gender = _gender;
            }
    
            public string Gender
            {
    
                get { return gender; }
                set
                {
                    //value = de doorgegeven data
                    if (value == "m" || value == "v")
                    {
                        gender = value;
                    }
                    else
                    {
                        gender = "Error: not a valid gender!";
                        isPersonStateValid = false;
                    }
                }
            }
    
            public bool IsPersonModelStateValid
            {
                get { return isPersonStateValid;}
                private set { isPersonStateValid = value; }
            }
    
            /*public static void addPerson(string name, int age, string _gender)
            {
                Personlist.Add(new Person(name, age, _gender));
            }*/
    
            public static void Speak(string name, int age, string _gender)
            {
                //TODO : The logic to make the person speak goes in here.
            }
    
            public void PrintPerson()
            {
                Console.WriteLine("name : " + this.name);
                Console.WriteLine("age : " + this.age);
                Console.WriteLine("gender : " + this.gender);
            }
        }
    }
