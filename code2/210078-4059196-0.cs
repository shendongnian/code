    abstract class Car
    {
        public abstract Engine CarEngine { get; protected set; }
        public Car(Engine carEngine)
        {
            CarEngine = carEngine;
            CarEngine.EngineOverheating += new EventHandler(CarEngine_EngineOverheating);
        }
        void CarEngine_EngineOverheating(object sender, EventArgs e)
        {
            // Subscribing to the event of all engines 
        }
    }
    sealed class Toyota : Car
    {
        public Toyota()
            : base(new ToyotaEngine())
        {
        }
        public override Engine CarEngine { get; protected set; }
    }
