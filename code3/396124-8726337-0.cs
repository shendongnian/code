    public class GiraffeProcessor : AnimalProcessor 
    {     
        public override IList<Animal> ProcessResults() 
        {         
            return new List<Giraffe>().Cast<Animal>();
        } 
    }
