    using System.Web.Mvc;
    public class MyModel {
        [Bind(Prefix = "L")]
        public string[] LongPropertyName { get; set; }
    }
