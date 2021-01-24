using (var sha2 = System.Security.Cryptography.SHA256.Create())  
{
    var hash = sha2.ComputeHash(Encoding.Unicode.GetBytes("MUÑOZ"));
    {
        string hexString = string.Empty;
    
        for (int i = 0; i < hash.Length; i++)
        {
            hexString += hash[i].ToString("X2");
        }
        Console.WriteLine(hexString);        
    }    
}
Produces :
    276DB000BF524070F106A2C413942159AB5EF2F5CA5A5B91AB2F3B6FA48EE1ED
Which is the same as SQL Server's hash string
