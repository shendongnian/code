	public static class JsonExtensions
	{
		public static JProperty Rename(this JProperty old, string newName)
		{
			if (old == null)
				throw new ArgumentNullException();
			var value = old.Value;
			old.Value = null;   // Prevent cloning of the value by nulling out the old property's value.
			var @new = new JProperty(newName, value);
			old.Replace(@new);  // By using Replace we preserve the order of properties in the JObject.
			return @new;
		}
		
        public static JProperty MoveTo(this JToken token, JObject newParent)
        {
            if (newParent == null || token == null)
                throw new ArgumentNullException();
			var toMove = (token as JProperty ?? token.Parent as JProperty);
			if (toMove == null)
				throw new ArgumentException("Incoming token does not belong to an object.");
			if (toMove.Parent == newParent)
				return toMove;
            toMove.Remove();
            newParent.Add(toMove);
			return toMove;
        }
	}
