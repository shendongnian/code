    public partial class KeyIdObject
    {
        public string key { get; set; }
        public long? T_id { get; set; }
        public List<KeyIdObject> Children { get; set; }
	}
    public partial class KeyIdObject
	{
        public static List<KeyIdObject> ToIdObjects(JToken root)
        {
            return root.TopDescendantsWhere<JObject>(o => true)
                .Select(o => new KeyIdObject { key = ((JProperty)o.Parent).Name, T_id = (long?)o["T_id"], Children = ToIdObjects(o) })
                .ToList();
        }
    }
