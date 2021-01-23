		public static void Trace() {
			var stack = new StackTrace(1, true);
			var frame = stack.GetFrame(0);
			var method = frame.GetMethod();
			var type = method.DeclaringType;
			Console.WriteLine(type);
			foreach (var i in type.GetInterfaces()) {
				Console.WriteLine(i);
			}
		}
