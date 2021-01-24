    public class User : BaseModel
    {
        public User()
        {
            fields = new List<String> {
                "id",
                "email",
                "name",
                "password"
            };
        }
    }
