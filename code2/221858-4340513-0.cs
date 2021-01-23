    var result = MD5.Create().ComputeHash(new byte[] { 0 });
    Console.WriteLine(result.Length);
    Console.WriteLine(Convert.ToBase64String(result));
    Console.WriteLine(result.Aggregate(new StringBuilder(),
                                        (sb, v) => sb.Append(v.ToString("x2"))));
    //16
    //k7iFrf4NoInN9jSQT9WfcQ==
    //93b885adfe0da089cdf634904fd59f71
    File.WriteAllBytes("tempfile.dat", result);
    var input = File.ReadAllBytes("tempfile.dat");
    Console.WriteLine(input.Length);
    Console.WriteLine(Convert.ToBase64String(input));
    Console.WriteLine(input.Aggregate(new StringBuilder(), 
                                        (sb, v) => sb.Append(v.ToString("x2"))));
    //16
    //k7iFrf4NoInN9jSQT9WfcQ==
    //93b885adfe0da089cdf634904fd59f71
