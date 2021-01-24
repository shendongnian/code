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
If all you want to know is if you have a value that can be created using the enum flags.. that's pretty easy, as long as we can assume that each flag is "sequential" (e.g. there are no gaps between the flags). All numbers between 1 and the sum of all flag values can be made by some combination of flags. You can simply sum the flag values together and compare that to your question value.
public static bool IsValidFlags<T>(int checkValue) where T:Enum {
	int maxFlagValue = ((int[])Enum.GetValues(typeof(T))).Sum();
	return (0 < checkValue) && (checkValue <= maxFlagValue);
}
For future reference, you can constrain your generic parameter to an enum:
void fx<T> () where T:Enum { }
