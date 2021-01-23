    sealed class Toyota : Car
    {
        public Toyota()
        {
        }
        public override Engine CarEngine
        {
            get
            {
                var engine = base.CarEngine;
                if (engine == null)
                {
                    engine = new ToyotaEngine();
                    base.CarEngine = engine;
                }
                return engine;
            }
        }
    }
