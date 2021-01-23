    public class MakeAppleFallCommandHandler
    {
        public void Execute(Apple apple)
        {
          //This method would be called whenever any apple in the farm falls
      
          FallFromTree(apple);
        }
        public event EventHandler<FallEventArgs> FallFromTree;
    }
