    public interface IAnimal
    {
        void Move();
    }
    public class Bird : IAnimal
    {
        public void Move()
        {
            //Realize that this is a type-specific behavior,
            //which could be different for each class that
            //implements IAnimal, NO NEED FOR UNBOXING
            //or a bunch of IFS!!!
            Console.WriteLine("Im flying!");
        }
    }
    public class Horse : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Im running!");
        }
    }
    //Then you may use it this way;
    listOfIAnimals.ForEach(c => c.Move());
