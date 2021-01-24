var args=String.Join("-",Environment.GetArguments());
var mutexName=$@"Global\{sExeName}-{args}";
var mutex = new Mutex(true, mutexName, out bCreatedNew);
A better idea would be to hash the arguments first, and use the hash as the name. Using a hash method [like the one in this answer](https://stackoverflow.com/a/38043979/134204), you can calculate the arguments has from the joined string :
static string GetSha256Hash(string input)
{
    var hasher=SHA256.Create();
    byte[] data = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
    StringBuilder sBuilder = new StringBuilder();
    // Loop through each byte of the hashed data 
    // and format each one as a hexadecimal string.
    for (int i = 0; i < data.Length; i++)
    {
        sBuilder.Append(data[i].ToString("x2"));
    }
    // Return the hexadecimal string.
    return sBuilder.ToString();
}
...
var args=String.Join("-",Environment.GetArguments());
var argHash=GetSha256Hash(args);
var mutexName=$@"Global\{sExeName}-{argHash}";
var mutex = new Mutex(true, mutexName, out bCreatedNew);
