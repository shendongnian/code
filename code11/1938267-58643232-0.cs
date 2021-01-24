public static byte[] StringToByteArray(string hex)
{
    return Enumerable.Range(0, hex.Length)
        .Where(x => x % 2 == 0)
        .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
        .ToArray();
}
* You seem to have encoded your RSA key wrong into XML which also gives you a mismatch.
Correcting those two things;
string dataForSign = "456456" + "43223174" + "2016-11-28T14:57:50+0100" + "1148034147085158089";
string signature = "247A9B78E3FE5D4376B6A0DC2E6D721653E748F35473AFCD575FF8707CE6D8933E367B3D52E1EA6D2F2E22279F4EF5C144B48988352B02976D6CB864D947B02469DE7101A371FD4342E7C173F3C4C079B3E13B35D7FA60025A360A347D2A962B12BB3607E986CD32B149D4ADA87D94B4C4D632440066AFB8017527095420DFEC74C42D6D953FF292FB323FE59332ED81E7F227ACDDCC20AE54F9791F9A0C572ACB534278FD5850AB582E33D357448FE007702B6DB93C773DBB2349B00AF5D9FB116C70A70CF4EDCB95CD20D1D47705ADB7FBF38AF910289A128F08FFF2EB20C1BDF809D8D1EC9F0E3CAEBAE5593281ED50838807ED92B77B84F881B00490C56E";
string publicKey =
    "<RSAKeyValue><Modulus>94CbbAspiut6qnC1iLzSJY4kmEgW/euPenOvMCB0EbbjSBVncx1Vi6UvbY86bu/3ZMgDBdhcq9fvqrdL2WLvacPWnHgIGCRV/8tlGs7oAcKei9V6OcyRjh0jD4TwBGqDUbQEfBXkLL1kJB8nPsLcUVrhmwGKM3qKTchSutpnDipRRSufswM2b8ScGLMX8O5J/54o85UiSP/ZZYcx4UDEpolN0k31Xa3fDw3tYn9KlIahALzgOqksF9jbv7jKS/DzpJAmQptuoL3t/0kj9J3tujh1NBpMoac7cCBiVCc+LVHga1Okn0R/1RotceYbkl6TaLW4O56XF5QorlHlkBWY5w==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
byte[] dataForSignAsBytes = Encoding.UTF8.GetBytes(dataForSign);
byte[] signatureAsBytes = StringToByteArray(signature);
RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider();
rsaCryptoServiceProvider.FromXmlString(publicKey);
var hashData = SHA256.Create().ComputeHash(dataForSignAsBytes);
var result1 = rsaCryptoServiceProvider.VerifyData(dataForSignAsBytes, CryptoConfig.MapNameToOID("SHA256"), signatureAsBytes);
var result2 = rsaCryptoServiceProvider.VerifyHash(hashData, CryptoConfig.MapNameToOID("SHA256"), signatureAsBytes);
var result3 = rsaCryptoServiceProvider.VerifyHash(hashData, signatureAsBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
var result4 = rsaCryptoServiceProvider.VerifyData(dataForSignAsBytes, signatureAsBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
Console.WriteLine(result1);
Console.WriteLine(result2);
Console.WriteLine(result3);
Console.WriteLine(result4);
...gives true/true/true/true.
