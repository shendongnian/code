    public class GiraffeProcessor : AnimalProcessor 
    {     
        private List<Giraffe> _innerList = new List<Giraffe>();
        public override IList<Animal> ProcessResults() 
        {         
            return new List<Animal>(innerList );        } 
    }
