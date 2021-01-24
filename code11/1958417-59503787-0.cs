        public abstract class BaseModel
        {
            public List<String> fields = new List<string>();
            public int select()
            {
                //ex : this here the fields is null; but this class being abstract means
                // I can only call this from an inherited class of this (child class)
                // which will have the fields attributes override
                return this.fields.Count();
            }
        }
        public class User : BaseModel
        {
            public User()
            {
                var theFields = new List<String> {
                    "id",
                    "email",
                    "name",
                    "password"
                };
                fields.AddRange(theFields);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var user = new User();
                var q = user.select();
            }
        }
