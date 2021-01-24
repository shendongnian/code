    struct product 
    {
      public int x;
      public double w;
    }
    var products = new product[10];
    for (int i = 0 ; i < 5 ; i++ )
    {
      products [i].x = products [i - 1].x;
    }
