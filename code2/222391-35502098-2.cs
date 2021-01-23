    var f = 10000000;
    var p = new int[f];
    for(int i = 0; i < f; ++i)
    {
	    p[i] = i % 2;
    }
    var time = DateTime.Now;
    p.Sum();
    Console.WriteLine(DateTime.Now - time);
    int x = 0;
    time = DateTime.Now;
    foreach(var item in p){
	   x += item;
    }
    Console.WriteLine(DateTime.Now - time);
    x = 0;
    time = DateTime.Now;
    for(int i = 0, j = f; i < j; ++i){
	   x += p[i];
    }
    Console.WriteLine(DateTime.Now - time);
