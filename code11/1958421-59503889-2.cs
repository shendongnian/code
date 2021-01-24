    public abstract class BaseModel
    {
        public virtual List<String> fields { get; set; } = new List<string>();
    }
    public class User : BaseModel
    {
        public override List<String> fields { get; set; } = new List<String> { "id", "email", "name", "password" };
    }
