        public class MyUser
        {
           public string Name { get; set; }
           public string Surname { get; set; }
           public int Age { get; set; }
        }
        public class UserCollection : Collection<MyUser>
        {
        }
