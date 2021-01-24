csharp
public static void Main()
{
    var privateKey= "<RSAKeyValue><Modulus>qltOYNlEOWNS4ACtgcIDzBkEyvJafolqakvAvtZeM9Vy6CK+ZD8mo0Xn1LkFXLMWjuCZBzXvaaaL8QQhT2iB1Kxas+nfQbgHhbRcNFisgaBRYiA5ilDuYPRoGXPDhuxysvjy/00CPpErdNqc/lSElpwNv0P5fwlwqPdZhBOxSL2WkRPkirSq06apACJ9UIP9d3lmgBkKJigGGDaJOjSotvtWZpONhnyr2ncHmREpaJd4O5hjxOESztMEHZf/LpoYsopEAVk+HAYbGf1J3MbzeL0nHupSGdVCG+YpJw0dHvujZEW4Q3+Ir4lGjDnntxcvffFUdH+cPsQuZyKD7fZ1rQ==</Modulus><Exponent>AQAB</Exponent><P>zNHC2XnpbcBr9iLf7Z3AoKD2SjgRcql4wwb/BeGFDFqRxS00T1tYd83AK2mBG1aqdyZH1idicTEM1TlW8FwhaO3kk0PoveBV5SVm537J8eG7MZ4yH0bKFYg8RjdkfrZppYHVCXE6ubEGTGOQGxTjjcUaLD9uqoorwPHKtOq8nY8=</P><Q>1Oz5iFxSnrZtUXcPcLAjoIQex3zDmgONyQEzVHndLHF6BO/9k6Dur2UiRfXQPltzEFfP8zZj1z+C7iuKfjnhOsRVour2A4gDduyezaHLb/4kCht2Sx8NB3wduAtsZr+8UmRJPeLvkEcN8+e0kG1oFHibUn7LiJv+RK/0wyeBEwM=</Q><DP>u7idH3nvChpMWQFJv5zQSeh9EzUkOLU+63DkF93Edbgk1lVCFmGgSd2X/bHrFMVv41iAirT6MshD/MFa/11RebxfvOGG1VBhKW4ITLAWIs1DJozZX3UgDnAY3joyrzg8x+ag/NB8hGjNXwH5t/iDPxKhlGBm64NL6sExinOCf90=</DP><DQ>rluHUrRXK4QzLHyUdjCmW/EUy0JNYjb6ydhj0g8goB4kTxq+yT8FdTcZw7Qw3H9CT+W4cW7efwqRCrs443g+CUNw5MIGxomAXMgSmkydLI4tsOEgEw/QOYrXQziHgfQMIGPi3fyRM9IbiNj6MTKGAg1pEzqlLK6gnlp/0bbtqUU=</DQ><InverseQ>G9FE60+miTihgULQbXu2xl6hCsdSUN7P5AtzxoZQYh5TNhytkMhDw7CXPnGaXLUCt5KUA8hax+kM9XbxP1fheRAe0llf1k7f6PEaWotposAbcS3GYjL2zZzRZTppsF3HO8/NTR6auYcDlz9f66kJqMYGnWMe/NrLKuRc4/rmbIQ=</InverseQ><D>Amgz3U50llL+8sdPrEuvfgzEcpGmEa+jX0keuhORVS4o53rGMehqhVgRhIHwv3SQVwh5YQ60CUwfIhKq3dJeM0EULwKY8vbEtHDt9JdkKJi5Taei6H9oPtp1Nhbapmdk336BAHZ4F6Y5dPc5zKYpEW+3CgLN3aumedy02RbmJF7zgJ1X7XDe2/TS8Xy7bXAQWyGryQt242VDskI8300d47Xqx4anwDgtXajNzpcVOkDS0/qjM92/CkHtAi8iL+XD83MuHtE4PdmtAVHQOjCBHCXWk6GwwmxO3dxPJtZq+um5+JhaEiekMTdoFTbh2OUfY870oBSu/XgAJ3nUyw/7SQ==</D></RSAKeyValue>";
    string connectionString = "NccK+nelOKXcLSd5kckt1jKQFu7nos1EpS8LITzjB8dO1R4anPoAkQlq4GD/cIJKznUVByJkzf4y8LfnufEVlpz0WsdCkxVkL65QlHL/HZzWXAyR9OJ1/Fveeu26aEJ7yMqGnX0EDmIckL9iY+DHyhKB3duCTcUnKfb7JTUbBmcdV2mkNQUxFgA1w6pSIq7gE7AG5JKPzfKfIvp+DPn3rYTY/DarsmeCwHFnWgV0WTQNzzh6c5retiCYPHwKXd4EzliwIvjhhfBOzsbszWV53vcE3talArnepShDCs9jjk3EUK0ptMp2CXbe7IyNeAgjNO9wTnp1dHNlrI9YLVZvuw==";
    var bytesCypherText = Convert.FromBase64String(connectionString);
    var csp = new RSACryptoServiceProvider();
    var rsaParam = ParseXmlString(privateKey);
    csp.ImportParameters(rsaParam);
    var bytesPlainTextData = csp.Decrypt(bytesCypherText, false);
    // Note The Encoding must be the SAME as how you convert string to bytes : 
    //    Here we use Unicode
    var plainText =  System.Text.Encoding.Unicode.GetBytes("hello,world");
    var x = csp.Encrypt(plainText, false);
    var plainTextData = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);
    Console.WriteLine(plainTextData);
}
Here the `ParseXmlString(string xml)` is mostly [copied from GitHub](https://github.com/dotnet/core/issues/874#issuecomment-323894072)
csharp
public static RSAParameters ParseXmlString( string xml){
    RSAParameters parameters = new RSAParameters();
    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
    xmlDoc.LoadXml(xml);
    if (! xmlDoc.DocumentElement.Name.Equals("RSAKeyValue")) {
        throw new Exception("Invalid XML RSA key.");
    }
    foreach (System.Xml.XmlNode node in xmlDoc.DocumentElement.ChildNodes)
    {
        switch (node.Name)
        {
            case "Modulus": parameters.Modulus = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "Exponent": parameters.Exponent = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "P": parameters.P = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "Q": parameters.Q = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "DP": parameters.DP = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "DQ": parameters.DQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "InverseQ": parameters.InverseQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "D": parameters.D = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
        }
    }
    return parameters;
}
### Test
A powershell that tests above code:
powershell
$rsa = New-Object System.Security.Cryptography.RSACryptoServiceProvider -ArgumentList 2048
# export private key to xml
$rsa.ToXmlString($true) | Out-File key.private.xml
# plain 
$p =[System.Text.Encoding]::Unicode.GetBytes( "hello,world"); 
# cipher (bytes)
$c = $rsa.Encrypt($p, $false)
# cipher (base64)
$ct = [Convert]::ToBase64String($c)
#decrypted (bytes)
$d = $rsa.Decrypt($c, $false);
[System.Text.Encoding]::Unicode.GetString($d);
