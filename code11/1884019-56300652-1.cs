    static void Main(string[] args)
    {
       var scores = new long[]{1, 34, 565, 43, 44, 56, 67};   
       var alice = new long[]{578, 40, 50, 67, 6};
    
       var ranks = GetRanks(scores, alice);
    
       foreach (var rank in ranks)
          Console.WriteLine(rank);
    
    }
