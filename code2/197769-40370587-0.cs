    using Newtonsoft.Json;
    class SerializationTests
    {
        public void DictionarySerializeSample()
        {
            var dict = new Dictionary<string, object>
            {
                {"fName", "John"},
                {"lName", "Doe"},
                {"email", "john@doe.net"}
            };
            string dictInJson = JsonConvert.SerializeObject(dict);
            var member = JsonConvert.DeserializeObject<Member>(dictInJson);
            // use Newtonsoft to write out the object re-serialized
            Console.WriteLine(JsonConvert.SerializeObject(member, Formatting.Indented));
        }
        public class Member
        {
            public string fName;
            public string lName;
            public string email;
        }
    }
