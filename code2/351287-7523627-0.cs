    class Client{
        public string Name {get;set;}
        public Client(string name){
            this.Name = name;
        }
    }
    
-- 
    class Job:Client{
        public double Rate {get;set;}
        public Job(double rate){
            // This won't compile, because Client won't have its "name" parameter.
        } 
        public Job(string name, double rate) : base(name){
            // So you need to pass a parameter from your Job constructor using "base" keyword.
            this.Rate = rate;
        }
        public Job(double rate) : base("Default Name"){
            // You could do this, this is legal.
        } 
    }
