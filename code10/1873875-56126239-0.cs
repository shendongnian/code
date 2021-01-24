using System.Linq;
public static byte[] HexToByteArray(string s)
        {
            return Enumerable.Range(0, s.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(s.Substring(x, 2), 16))
                     .ToArray();
        }
        public static string ByteArrayToHex(byte[] b)
        {
            return BitConverter.ToString(b).Replace("-", "");
        }
