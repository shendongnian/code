    public class MyServiceThatNeedsDbContext {
        private static readonly MyContext _myContext;
        MyServiceThatNeedsDbContext(MyContext myContext) {
          _myContext = myContext;
        }
    }
