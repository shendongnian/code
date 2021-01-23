    public class TestViewModel : Controller
    {
        [ProtectedProperty("You changed me. you bitch!")]
        public string DontChangeMe { get; set; }
        public string ChangeMe { get; set; }
    }
