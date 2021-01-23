    public class PropertiesMatchConstraint : AbstractConstraint
	{
		private readonly object _equal;
		public PropertiesMatchConstraint(object obj)
		{
			_equal = obj;
		}
		public override bool Eval(object obj)
		{
			if (obj == null)
			{
				return (_equal == null);
			}
			var equalType = _equal.GetType();
			var objType = obj.GetType();
			foreach (var property in equalType.GetProperties())
			{
				var otherProperty = objType.GetProperty(property.Name);
				if (otherProperty == null || !_ValuesMatch(property.GetValue(_equal, null), otherProperty.GetValue(obj, null)))
				{
					return false;
				}
			}
			return true;
		}
		//fix for boxed conversions object:Guid != object:Guid when both values are the same guid - must call .Equals()
		private bool _ValuesMatch(object value, object otherValue)
		{
			if (value == otherValue)
				return true; //return early
			if (value != null)
				return value.Equals(otherValue);
			return otherValue.Equals(value);
		}
		public override string Message
		{
			get
			{
				string str = _equal == null ? "null" : _equal.ToString();
				return "equal to " + str;
			}
		}
	}
