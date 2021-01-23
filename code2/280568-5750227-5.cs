	using System;
    using System.Text;
	public static class MyClass {
		public static void Main() {
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			for (var i = 0; i <= 1000; i++) {
				Console.Write(Strings.ChrW(i));
				if (i % 50 == 0) { \\ break every 50 chars
					Console.WriteLine();
				}
			}
			Console.ReadKey();
		}
	}
