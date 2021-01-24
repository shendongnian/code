    StringBuilder sb1 = new StringBuilder();
    StringBuilder sb2 = new StringBuilder();
    sb1.Append("Id ");
    sb2.Append("Roll# ");
    for (int i = 0; i < 10; i++)
    {
        sb1.Append(i + " ");
        sb2.Append(i + " ");
    }
    Console.WriteLine(sb1);
    Console.WriteLine(sb2);
