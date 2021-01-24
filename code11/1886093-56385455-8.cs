    public partial class KeyIdObject
	{
        public static List<KeyIdObject> ToIdObjects(JToken root)
        {
            return root.TopDescendantsWhere<JObject>(o => o["T_id"] != null)
                .Select(o => new KeyIdObject { key = ((JProperty)o.Parent).Name, T_id = (long)o["T_id"], Children = ToIdObjects(o) })
                .ToList();
        }
    }
