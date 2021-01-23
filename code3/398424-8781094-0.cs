    string message = "[1312701386,transactioncreate,[account_code:ABC,amount_in_cents:5000,currency:USD]]";
    string privateKey = "0123456789ABCDEF0123456789ABCDEF";
    var hashedKey = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(privateKey));
    var hmac = new HMACSHA1(hashedKey);
    var hash = hmac.ComputeHash(Encoding.ASCII.GetBytes(message));
    
    Console.WriteLine("  Message: {0}", message);
    Console.WriteLine("      Key: {0}\n", privateKey);
    Console.WriteLine("Key bytes: {0}", BitConverter.ToString(hashedKey).Replace("-", "").ToLower());
    Console.WriteLine("   Result: {0}", BitConverter.ToString(hash).Replace("-", "").ToLower());
