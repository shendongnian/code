    @decPL I made it work with the singleton pattern doing this `    public sealed class Singleton
    {
        Singleton()
        {
        }
        private static readonly object padlock = new object();
        private static Singleton instance = null;
        public static EE.Observador watcher = new Observador();
        private Usuario userInstance = null;`
