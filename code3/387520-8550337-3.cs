    class Stuff
    {
       public int Thing { get; set; }
    }
    
    ...
    
    cnn.Execute("select @Thing", new Stuff{Thing = 1});
