c#
using System.Linq;
//...
int[] integers = {0x0004,0x0001,0x0003,0x0003};
byte[] bytes = integers.Select(n => (byte)(n & 0xFF)).ToArray();
