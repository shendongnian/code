    public class MyServiceThatNeedsDbContext {
        private readonly MyContext _myContext;
        MyServiceThatNeedsDbContext(MyContext myContext) {
          _myContext = myContext;
        }
    }
