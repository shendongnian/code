cs
string hex = "babe";
byte[] bytes = new byte[hex.Length / 2];
for (int i = 0; i < hex.Length; i += 2) {
 	bytes[i/2] = Convert.ToByte(hex.Substring(i, 2), 16);
}
		
string converted = System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
Console.WriteLine(converted);
