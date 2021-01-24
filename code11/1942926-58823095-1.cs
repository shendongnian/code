    struct product 
    {
      public int x;
      public double w;
    }
    var products = new product[10];
    for (int index = 0; index < product.Length; index++)
      products[index] = new product();
    for (int i = 1 ; i < 5 ; i++ )
    {
      products [i].x = products [i - 1].x; // beware 0-1 = -1
    }
