	[ComVisible(true)]
	public class ObjectForScripting {
		public void Call(dynamic o) {
			Type t = o.GetType();
			var result = t.InvokeMember("a", System.Reflection.BindingFlags.GetProperty, null, o, null);
		}
	}
