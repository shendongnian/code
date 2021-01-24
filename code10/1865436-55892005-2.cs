     [Config(typeof(ConfigWithCustomEnvVars))]
        public class DrawManagedVsDrawNative
        {
            private class ConfigWithCustomEnvVars : ManualConfig
            {
                private const string EnvVar = "Env_Var_Sample";
                
                public ConfigWithCustomEnvVars()
                {
                    Add(Job.Core.WithId("Variable not set"));
                    Add(Job.Core
                        .With(new[] { new EnvironmentVariable(EnvVar, "1") })
                        .WithId("Variable set"));
                }
            }
    
        private DrawManaged drawManaged = new DrawManaged();
        private DrawNative drawNative = new DrawNative();
        private byte[] data;
    
    
        [GlobalSetup]
        public void Setup()
        {
           // Some initialization here
        }
    
        [Benchmark]
        public byte[] DrawManaged() => drawManaged.Draw();
    
        [Benchmark]
        public byte[] DrawNative() => drawNative.Draw();
    	
        }
