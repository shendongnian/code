	abstract class EditableProperty { }
	class EditableProperty<T> : EditableProperty {
		public void Set(T obj, object value) { Console.WriteLine(value); }
	}
	abstract class EditablePropertyMap {
		private static Dictionary<Type, EditablePropertyMap> maps = new Dictionary<Type, EditablePropertyMap>();
		abstract public void AddProperty(string name, EditableProperty property);
		abstract public void SetPropertyValue(object obj, string name, object value);
		static public EditablePropertyMap Get(Type t) {
			EditablePropertyMap map;
			if(!maps.TryGetValue(t, out map)) {
				map = (EditablePropertyMap)Activator.CreateInstance(
					typeof(EditablePropertyMap<>)
						.MakeGenericType(t));
				maps.Add(t, map);
			}
			return map;
		}
	}
	class EditablePropertyMap<T> : EditablePropertyMap {
		private Dictionary<string, EditableProperty<T>> properties = new Dictionary<string, EditableProperty<T>>();
		public override void AddProperty(string name, EditableProperty property) {
			properties.Add(name, (EditableProperty<T>)property);
		}
		public override void SetPropertyValue(object obj, string name, object value) {
			EditableProperty<T> property = properties[name];
			property.Set((T)obj, value);
		}
	}
	class DynamicObjectBase {
		public void SetPropertyValue(string name, object value) {
			EditablePropertyMap map = EditablePropertyMap.Get(GetType());
			map.SetPropertyValue(this, name, value);
		}
	}
	class SomeDynamicObject : DynamicObjectBase {
	}
	class Program {
		static void Main(string[] args) {
			EditablePropertyMap map = EditablePropertyMap.Get(typeof(SomeDynamicObject));
			map.AddProperty("wut", new EditableProperty<SomeDynamicObject>());
			SomeDynamicObject o = new SomeDynamicObject();
			o.SetPropertyValue("wut", 1);
		}
	}
