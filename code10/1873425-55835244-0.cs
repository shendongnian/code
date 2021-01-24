    public class Form
    {
        internal static Dictionary<string, Form> Cache = new
            Dictionary<string, Form>();
        public string FormID { get; private set; }
        public Form(string formID)
        {
            this.FormID = formID;
            if (!Cache.ContainsKey(formID))
                Cache.Add(formID, this); // <--- this instead of new Form();
        }
    }
