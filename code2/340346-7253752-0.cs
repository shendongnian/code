    class Result {
       public bool Part1 {get;set;}
       public bool Part2 {get;set;}
    }
    
    Result test() {
       return new Result {Part1 = true, Part2 = false};
    }
