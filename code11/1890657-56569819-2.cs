	class JTokenPrinter : IJTokenWorker
	{
		public bool ProcessToken<TConvertible>(JContainer parent, TConvertible index, JToken current, int depth) where TConvertible : IConvertible
		{
			var spacer = new String('\t', depth);
			string name;
			string val;
			
			if (parent != null && index is int)
				name = string.Format("[{0}]", index);
			else if (parent != null && index != null)
				name = index.ToString();
			else 
				name = "";
			
			if (current is JValue)
				val = ((JValue)current).ToString();
			else if (current is JConstructor)
				val = "new " + ((JConstructor)current).Name;
			else
				val = "-";
			
			Console.WriteLine(string.Format("{0}{1}   -> {2}", spacer, name, val));
			return true;
		}
	}
	
	public static void Convert(string json)
	{
		var root = JsonConvert.DeserializeObject<JToken>(json);
		root.WalkTokens(new JTokenPrinter());
	}
