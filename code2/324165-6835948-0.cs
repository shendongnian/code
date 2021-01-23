    public interface IGameStrategy {
        void Move(Actor actor, MoveDirection direction);
    }
    
    public class ConsoleGameStrategy : IGameStrategy {
        public void Move(Actor actor, MoveDirection direction)
        {
            // basic console implementation
            Console.WriteLine("{0} moved {1}", actor.Name, direction);
        }
    }
    
    public class Actor {
        private IGameStrategy strategy; // hold a reference to strategy
    
        public Actor(IGameStrategy strategy)
        {
            this.strategy = strategy;
        }
    
        public void RunForrestRun()
        {
            // whenever I want to move this actor, I may call strategy.Move() method
            for (int i = 0; i < 10; i++)
                strategy.Move(this, MoveDirection.Forward);
        }
    }
    // when creating Actors, specify the strategy you want to use
    var strategy = new ConsoleGameStrategy();
    var actor = new Actor(strategy);
