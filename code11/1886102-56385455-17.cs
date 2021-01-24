    public partial class IdObject
    {
        public long T_id { get; set; }
        public Dictionary<string, IdObject> Children { get; set; }
	}
    public partial class IdObject
	{
        public static Dictionary<string, IdObject> ToIdObjects(JToken root)
        {
            return root.TopDescendantsWhere<JObject>(o => o["T_id"] != null)
				.ToDictionary(o => ((JProperty)o.Parent).Name, 
							  o => new IdObject { T_id = (long)o["T_id"], Children = ToIdObjects(o) });
        }
    }
