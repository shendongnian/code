    public Dictionary<string, object> GetObjectFields(object obj) {
		var dict = new Dictionary<string, object>();
		var t = obj.GetType();
		foreach(var f in t.GetFields()) {
			dict[f.Name] = f.GetValue(obj);
		}
		return dict;
	}
