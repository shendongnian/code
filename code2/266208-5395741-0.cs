    public interface IShowTimeUpdatedVisitor
    {
        void Visit(Lion lion);
        void Visit(Elephant lion);
        void Visit(IAnimal animal);
    }
    public class ShowTimeUpdatedVisitor : IShowTimeUpdatedVisitor
    {
        public void Visit(Lion lion)
        {
            //do stuff with a lion
        }
        public void Visit(Elephant elephant)
        {
            //do stuff with an elephant
        }
        public void Visit(IAnimal animal)
        {
            // this will be the default which will be hit if no Visit method for the concrete exists
        }
    }
