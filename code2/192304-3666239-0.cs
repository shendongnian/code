    public Boolean MyMethod(String param) {
     try {
      AspectF.Define
       .ErrorMsgIfNull(param, "must be not null")
       .ErrorMsgIfEquals(new string[] {"None", "Zero", "0"}, "may not be zero")
       //...
       // use your own "AspectFlets" you wrote
       //...
       .Do(() =>
        {
         // Do some stuff with param
         // This is not executed if param is null, as the program stops a soon
         // as one of the above exceptions is thrown
        });
    }
