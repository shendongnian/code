    public Program GetProgram(){
        if(someDataCoulumn.Equals("Static")) {
            return new StaticProgram(...);
        } else {
             return new DynamicProgram(...);
        }
    }
    public void Caller(){
        var p = GetProgram();
        var sp = p as StaticProgram;
        if(sp != null) {
           DoSomethingWithStaticProgram(sp);
        } else {
           var dp = p as DynamicProgram;
           if(dp != null){
               DoSomethingWithDynamicProgram(dp);
           } else {
               throw new SomeBusinessException("Program is neither Static not Dynamic, instead it's " + p.GetType().FullName);
           }
        }
        
    }
