	class Node<T> 
	{
		event EventHandler Changed;
		private T _value;
		private bool _dirty = true;
		private List<Node<T>> _children = new List<Node<T>>();
		public void AddChild(Node<T> child)
		{
			child.Changed += (s,e) => _dirty = true;
            _children.Add(child);
		}
		protected void OnChanged()
		{
			if (Changed != null) Changed(this, new EventArgs());
		}
		public T Value
		{
			get
			{
				if (_dirty)
				{
					this.Value = ComputeValueFromChildren();
					_dirty = false;
				}
				return _value;
			}
			set
			{
				_value = value;
				OnChanged();
			}
		}
		private T ComputeValueFromChildren()
		{
			var values = _children.Select( child => child.Value );
			//Return the new value based on the children
		}
	}
