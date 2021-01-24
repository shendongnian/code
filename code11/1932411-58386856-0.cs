Guid GenerateGuid(string input)
{
	byte[] _byteIds = Encoding.UTF8.GetBytes(input);
	MD5CryptoServiceProvider _md5 = new MD5CryptoServiceProvider();
	byte[] _checksum = _md5.ComputeHash(_byteIds);
	//Convert checksum into 4 ulong parts and use BASE36 to encode both
	string part1 = BitConverter.ToString(_checksum, 0, 4).Replace("-", string.Empty);
	string part2 = BitConverter.ToString(_checksum, 4, 2).Replace("-", string.Empty);
	string part3 = BitConverter.ToString(_checksum, 6, 2).Replace("-", string.Empty);
	string part4 = BitConverter.ToString(_checksum, 8, 2).Replace("-", string.Empty);
	string part5 = BitConverter.ToString(_checksum, 10, 6).Replace("-", string.Empty);
	return Guid.Parse($"{part1}-{part2}-{part3}-{part4}-{part5}");
}
