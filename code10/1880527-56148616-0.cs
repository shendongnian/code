using System;
class Program {
	const Int32 maxTriangleSize = 5;
	static void Main(string[] args) {
		for (Int32 i = maxTriangleSize - 1; i >= 0; i--) {
			Console.WriteLine(new String('*', i + 1));
		}
		for (Int32 i = 0; i < maxTriangleSize; i++) {
			Console.WriteLine(new String('*', i + 1));
		}
		Console.ReadLine();
	}
}
