    public abstract class BaseModel
    {
        public List<String> fields = new List<string>();
    }
    public class User : BaseModel
    {
        public User()
        {
            fields.AddRange(new List<String> {
                "id",
                "email",
                "name",
                "password"
            });
        }
    }
