    List<double?> dArr = new List<double?>( )
    {
       1,
       3,
       null,
       5
    };
         
    double sum = dArr.Select( item =>
       {
           if( item.HasValue == false )
              return 0;
           else
              return item;
       } ).Sum( item => item.Value );
