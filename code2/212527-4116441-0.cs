    string s1 = "ZABCDEF";
    string s2 = "ZBCCEFG";
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < s1.Length; ++i)
    {
        if (s1[i] == s2[i])
        {
            sb.Append(s1[i]);
            Console.WriteLine("  " + s1[i]);
        }
        else
        {
            sb.Append("[" + s1[i] + s2[i] + "]");
            Console.WriteLine(s1[i] + "   " + s2[i]);
        }
    }
    Console.WriteLine(sb);
