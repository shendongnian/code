    dynamic Dict {
	    get {
		    return new DynamicDictFactory ();
		}
	}
	private class DynamicDictFactory : DynamicObject
	{
		public override bool TryInvoke (InvokeBinder binder, object[] args, out object result)
		{
			var res = new Dictionary<string, object> ();
			var names = binder.CallInfo.ArgumentNames;
			for (var i = 0; i < args.Length; i++) {
				var argName = names [i];
				if(string.IsNullOrEmpty(argName)) throw new ArgumentException();
				res [argName] = args [i];
			}
			result = res;
			return true;
		}
	}
