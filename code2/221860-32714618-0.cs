    var p = new MD5CryptoServiceProvider();
	var dic = new Dictionary<long, string>();
	for (var i = 0; i < 10000000; i++)
	{
		if (i%25000 == 0)
			Console.WriteLine("{0:n0}", i);
		var h = p.ComputeHash(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
		var b = BitConverter.ToInt64(h, 0);
        // "b" is hashed Int64
		if (!dic.ContainsKey(b))
			dic.Add(i, null);
		else
			throw new Exception("Oops!");
    }
