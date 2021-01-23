    public class MyApp : IApp
    {
        public virtual void Run()
        {
            Hello.SayHello();
        }
        [Inject]
        public IHello Hello { get; set; }
    }
