    public class Worker 
    {
        private readonly ISettings settings;
        public Worker (ISettings settings)
        {
            this.settings = settings;
        }
        public void Work ()
        {
            for (int i = 0; i < settings.MaxWorkerIterations (); i++)
            { ... }
        }
    }
    public interface ISettings
    {
        int MaxWorkerIterations ();
    }
    public class AppConfigSettings
    {
        public int MaxWorkerIterations ()
        {
            return (int) ApplicationSettings["MaxWorkerIterations"];
        }
    }
