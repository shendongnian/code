    public static class WyamConfiguration {
        public static void Embed(Action<Wyam.Core.Execution.Engine> configure) {
            // you will need to create an instance of the Wyam.Core.Execution.Engine class
            var engine = new Wyam.Core.Execution.Engine();
            // configure the engine
            configure(engine);
            // Once the engine is configured, execute it with a call to Engine.Execute()
            // This will start evaluation of the pipelines and any output messages will 
            // be sent to the configured trace endpoints.
            engine.Execute();
        }
    }
