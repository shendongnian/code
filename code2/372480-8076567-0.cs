       public string shuffleme(List<Tuple<string,int> playlist, int prioritiesSum)
       { 
          Random random = new Random();
    
          foreach(var song in playlist)
          {
             var prob=random.NextDouble(); //0.0-1.0
             if (prob < song.Item2/(double)prioritiesSum)
                return song.Item1;
             else
                prioritiesSum-=song.Item2;
          }
       }
