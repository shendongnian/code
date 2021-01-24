    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Friends
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var data = new GenerateExampleData();
                var lstFriendId = (from f in data.lstFriend
                                   where f.PersonId == 2
                                   select f.FriendId
                                  );
    
                var lstMutualFriend = (from f in data.lstFriend
                                       join p in data.lstPerson on f.FriendId equals p.Id
                            where lstFriendId.Contains(f.FriendId) && f.PersonId == 1
                            select p.Name
                           );
                foreach (var item in lstMutualFriend)
                {
                    Console.WriteLine(item);
                }           
                Console.ReadLine();
            }
        }
    
        public class GenerateExampleData
        {
            public List<Person> lstPerson;
            public List<Friendship> lstFriend;
    
            public GenerateExampleData()
            {
                lstPerson = new List<Person>
                {
                    new Person
                    {
                        Id = 1,
                        Name ="Person1"
                    },
                    new Person
                    {
                        Id = 2,
                        Name ="Person2"
                    },
                    new Person
                    {
                        Id = 3,
                        Name ="Person3"
                    },
                    new Person
                    {
                        Id = 4,
                        Name ="Person4"
                    },
    
                };
    
                lstFriend = new List<Friendship>
                {
                    new Friendship
                    {
                        PersonId = 1,
                        FriendId = 2
                    },
    
                    new Friendship
                    {
                        PersonId = 1,
                        FriendId = 4
                    },
    
                    new Friendship
                    {
                        PersonId = 2,
                        FriendId = 4
                    },
                };
            }
    
        }
    
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        public class Friendship
        {
            public int PersonId { get; set; }
            public int FriendId { get; set; }
        }
    
    }
