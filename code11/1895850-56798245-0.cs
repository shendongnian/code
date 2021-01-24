    public class Reviewer
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Reviewer reviewer = new Reviewer();
            string json = @"[
                            { Name: ""Jason"" , Age: 20 , Address: ""London""},
                            { Name: ""Andy"" , Age: 35, Address: ""Boston""},
                            { Name: ""Mike"", Age: 27,Address: ""California""},
                            { Name: ""Maria"", Age: 22,Address: ""Arizona"" }]";
            var data = JArray.Parse(json).ToList();
            List<string> values = new List<string>();
            var props = typeof(Reviewer).GetProperties();
            foreach (var prop in props)
            {
                foreach (JObject item in data)
                    values.Add(item.GetValue(prop.Name).ToString());
                prop.SetValue(reviewer, string.Join(", ", values), null);
                values.Clear();
            }
        }
    }
