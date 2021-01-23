     double value = 0.1;
     ThreadPool.QueueUserWorkItem( () => value = Process(value)); // use captured variable
     // -- OR --
     ThreadPool.QueueUserWorkItem( () =>
          {
               double val = value;      // use explicit parameter
               val = Process(val);      // value is not changed
          }); 
     // -- OR --
     ThreadPool.QueueUserWorkItem( (v) =>
          {
               double val = (double)v;  // explicit var for casting
               val = Process(val);      // value is not changed
          }, value); 
