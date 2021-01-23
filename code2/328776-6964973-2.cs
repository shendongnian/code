      public static object GenericClone(object Obj)
    {
	object @out = null;
	@out = Activator.CreateInstance(Obj.GetType());
	Type mytype = Obj.GetType();
	while (mytype != null) {
		foreach (System.Reflection.FieldInfo item in mytype.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)) {
			object itemValue = item.GetValue(Obj);
			object newvalue = null;
			if (itemValue != null) {
				if (typeof(System.ICloneable).IsAssignableFrom(itemValue.GetType())) {
					newvalue = ((System.ICloneable)itemValue).Clone();
				} else {
					if (itemValue.GetType().IsValueType) {
						newvalue = itemValue;
					} else {
						if (itemValue.GetType().Name == "Dictionary`2") {
							newvalue = DataInterface.CloneDictionary(itemValue);
						} else if (object.ReferenceEquals(itemValue.GetType(), typeof(System.Text.StringBuilder))) {
							newvalue = new System.Text.StringBuilder(((System.Text.StringBuilder)itemValue).ToString());
						} else if (itemValue.GetType().Name == "List`1") {
							newvalue = DataInterface.CloneList(itemValue);
						} else {
							throw (new Exception(item.Name + ", member of " + mytype.Name + " is not cloneable or of value type."));
						}
					}
				}
			}
			//set new obj copied data
			mytype.GetField(item.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).SetValue(@out, newvalue);
		}
		//must move up to base type, GetFields does not return inherited fields
		mytype = mytype.BaseType;
	}
	return @out;
    }
    public static Dictionary<K, V> CloneDictionary<K, V>(Dictionary<K, V> dict)
    {
	Dictionary<K, V> newDict = null;
	// The clone method is immune to the source dictionary being null.
	if (dict != null) {
		// If the key and value are value types, clone without serialization.
		if (((typeof(K).IsValueType || object.ReferenceEquals(typeof(K), typeof(string))) && (typeof(V).IsValueType) || object.ReferenceEquals(typeof(V), typeof(string)))) {
			newDict = new Dictionary<K, V>();
			// Clone by copying the value types.
			foreach (KeyValuePair<K, V> kvp in dict) {
				newDict[kvp.Key] = kvp.Value;
			}
		} else {
			newDict = new Dictionary<K, V>();
			// Clone by copying the value types.
			foreach (KeyValuePair<K, V> kvp in dict) {
				newDict[kvp.Key] = DataInterface.GenericClone(kvp.Value);
			}
		}
	}
	return newDict;
    }
    public static List<T> CloneList<T>(List<T> list)
    {
	List<T> Out = new List<T>();
	if (typeof(System.ICloneable).IsAssignableFrom(typeof(T))) {
		return (from x in list(T)((ICloneable)x).Clone()).ToList;
	} else if (typeof(T).IsValueType) {
		return (from x in list(T)x).ToList;
	} else {
		throw new InvalidOperationException("List elements not of value or cloneable type.");
	}
}
