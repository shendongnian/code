    public abstract partial class KeyItemBase : INotifyPropertyChanged
    {
		public KeyItemBase() : this(null, Enumerable.Empty<KeyItemBase>()) { }
		public KeyItemBase(string key, IEnumerable<KeyItemBase> children)
		{
			this.m_key = key;
			this.m_children = new ObservableCollection<KeyItemBase>(children);
		}
		string m_key;
        public string key 
		{ 
			get { return m_key; }
			set
			{
				m_key = value;
				RaisedOnPropertyChanged("key");
			}
		}
		ObservableCollection<KeyItemBase> m_children;
        public ObservableCollection<KeyItemBase> Children { get { return m_children; } }
    	public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisedOnPropertyChanged(string _PropertyName)
		{
			var changed = PropertyChanged;
			if (changed != null)
			{
				changed(this, new PropertyChangedEventArgs(_PropertyName));
			}
		}
	}
	public abstract partial class KeyItemBase
	{
		// Generate clean JSON on re-serialization.
		public bool ShouldSerializeChildren() { return Children != null && Children.Count > 0; }
	}
	public sealed class KeyItem : KeyItemBase
	{
		// Use for a JSON object with no T_id property.
		// Bind an appropriate SfTreeView.ItemTemplate to this type.
	
		public KeyItem() : base() { }
		public KeyItem(string key, IEnumerable<KeyItemBase> children) : base(key, children) { }
	}
	public class KeyIdItem : KeyItemBase
	{
		// Use for a JSON object with a T_id property.
		// Bind an appropriate SfTreeView.ItemTemplate to this type.
	
		public KeyIdItem() : base() { }
		public KeyIdItem(string key, IEnumerable<KeyItemBase> children, long t_id) : base(key, children) { this.m_id = t_id; }
		long m_id;
        public long T_id 
		{ 
			get { return m_id; }
			set
			{
				m_id = value;
				RaisedOnPropertyChanged("T_id");
			}
		}
	}
	public static class KeyItemFactory
	{
		public static KeyItemBase ToKeyObject(string name, long? id, IEnumerable<KeyItemBase> children)
		{
			if (id == null)
				return new KeyItem(name, children);
			else
				return new KeyIdItem(name, children, id.Value);
		}
		
		public static IEnumerable<KeyItemBase> ToKeyObjects(JToken root)
		{
			return root.TopDescendantsWhere<JObject>(o => true)
				.Select(o => ToKeyObject(((JProperty)o.Parent).Name, (long?)o["T_id"], ToKeyObjects(o)));
		}
	}
