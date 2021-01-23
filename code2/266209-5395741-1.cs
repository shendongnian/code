    public interface IAnimal
    {
        void ShowTimeUpdated(IShowTimeUpdatedVisitor updatedVisitor);
    }
    public class Lion : IAnimal
    {
        public void ShowTimeUpdated(IShowTimeUpdatedVisitor updatedVisitor)
        {
            updatedVisitor.Visit(this);
        }
    }
