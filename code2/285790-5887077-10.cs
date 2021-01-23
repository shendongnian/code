    public class TestAnimals
    {
        protected static void DoMove<T>(T animal) where T : IAnimal
        {
            animal.Move();
        }    
        public void RunTest()
        {
            Duck duck = new Duck();
            Fish fish = new Fish();
            Ant ant = new Ant();   
 
            DoMove(duck);
            DoMove(fish);
            DoMove(ant);
        }
    }
    
