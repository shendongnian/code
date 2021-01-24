    List<int> Score = new List<int>();
    Random rdn = new Random();
    
    
    for(int i=0;i<rdn.Next(0,20);i++)
    {
    	Score.Add(rdn.Next());
    }
    
    int sum = 0;
    
    for (int i = 0; i < Score.Count; i++)
    {
        sum = sum + Score[i];
    }
    double average = sum / Score.Count;
