    public static Main()
    {
         var pack = Tuple.Create(1, 2, 10.4, 30.5, "Steve");
         CustomerCommandService ccs = new CustomerCommandService(pack);
    }
    public CustomerCommandService(Tuple<int,int,float,float,string> pack){
          //some code here
    }
