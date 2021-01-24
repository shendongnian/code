        Int32 userId { get; set; }
        Int32 id { get; set; }
        String title { get; set; }
        String completed { get; set; }
needed to be
        public Int32 userId { get; set; }
        public Int32 id { get; set; }
        public String title { get; set; }
        public String completed { get; set; }
the class now looks like
    public class RandomValue
    {
        public Int32 userId { get; set; }
        public Int32 id { get; set; }
        public String title { get; set; }
        public Boolean? completed { get; set; }
        public RandomValue() { }
        public RandomValue RandomVal(JObject obj)
        {
            RandomValue val = new RandomValue();
            val.userId = Int32.TryParse(obj.GetValue("userId").ToString(), out int userIdResult) ? userIdResult : 0;
            val.id =  Int32.TryParse(obj.GetValue("id").ToString(), out int idRes) ? idRes : 0;
            val.title = obj.TryGetValue("title", out JToken titleToken) ? titleToken.ToString() : null;
            if (obj.TryGetValue("completed", out JToken completed) && BooleanExtensions.TryParse(completed.ToString()))
            {
                val.completed = BooleanExtensions.Parse(completed.ToString());
            }
            return val;
        }
    }
I am still not sure why I needed to do this because it certainly seemed like the values were being assigned correctly when using the visual studio debugger so if anyone can explain it that would help
