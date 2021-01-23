    public class Car
    {
        public event Action<Car> Explode;
        private void OnExplode()
        {
            Explode(this);
        }
    }
    public class Game
    {
        private Car car;
        public Game()
        {
            car = new Car();
            car.Explode += new Action<Car>(NotifyExplosion);
        }
        private void NotifyExplosion(Car car)
        {
            Console.WriteLine("{0} is exploded", car.ToString());
            GameOver();
        }
        private void GameOver()
        {
            Console.WriteLine("GAME OVER");
        }
        static void Main(string[] args)
        {
            Game game = new Game();
        }
    }
