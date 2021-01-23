    int[] p = new int[10] { 2, 9, 13, 3, 50, -8, -30, 0, 1, 4 };
    int vsota = 0;
    float povprecje = 0;
    
    for (int i = 0; i < p.Length; i++)
    {
    	Console.WriteLine("p [{0}] = {1,3}", i, p[i]);
    	vsota += p[i];
    }
    povprecje = (float)vsota/p.Length;
    Console.WriteLine();
    Console.WriteLine("Vsota = {0}!", vsota);
    Console.WriteLine("Povprecje = {0}!", povprecje);
    Console.ReadKey(true);
    // Sort (low to high) the int[] by calling the Array.Sort() method
    Array.Sort(p);
    foreach(int i in p)
    {
    	Console.WriteLine(i);
    }
    
    // Sort (high to low) the int[] by calling the Array.Sort() method
    Array.Reverse(p);
    foreach(int i in p)
    {
    	Console.WriteLine(i);
    }
