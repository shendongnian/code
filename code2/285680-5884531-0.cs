    public interface IUnitOfWorkFactory
    {
        IUnitOfWork NewUnitOfWork();
    }
    public class MyController : Controller
    {
        private readonly IUnitOfWorkFactory factory;
        public MyController(IUnitOfWorkFactory factory)
        {
            this.factory = factory;
        }
        public void Operation()
        {
            using (var work = new this.factory.NewUnitOfWork())
            {
                work.Begin();
                // do some interesting stuff here.            
                work.End();
            }
        }
    }
