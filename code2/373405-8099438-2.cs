    int[] list = new int[7]; 
    var rn = new Random(Environment.TickCount);
    for (int i = 0; i < 7; i++) 
    { 
        var next = rn.Next(1, 50);
        while(Contains(list, next))
        {
            next = rn.Next(1, 50);
        }
        list[i] = next;       
    } 
    
    
    private bool Contains(IEnumerable<int> ints, int num) 
    {
        foreach(var i in ints)
        {
            if(i = num) return true;
        }
        return false;
    } 
