c#
using System;
namespace SO_58455415_enum_parsing {
	[Flags]
	public enum CheeseCharacteristics {
		Yellow = 1,
		Mouldy = 2,
		Soft = 4,
		Holed = 8
	}
    public static class Program {
        static void Main(string[] args) {
			CheeseCharacteristics cc = (CheeseCharacteristics)12;
			Console.WriteLine(cc);
		}
    }
}
For future reference, you can constrain your generic parameter to an enum:
void fx<T> () where T:Enum { }
