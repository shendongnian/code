    public abstract class BaseClass
    {
        public abstract void Execute();
        public virtual void Redirect()
        {
            // redirect code here
        }
    }
    public class Class1 : BaseClass
    {
        public override void Execute()
        {
            // do some processing
            this.Redirect();
        }
    }
    ..
    var class1Mock = Rhino.Mocks.MockRepository.GeneratePartialMock<Class1>();
    class1Mock.Expect(x => x.Redirect());
    class1Mock.Execute();
    class1Mock.VerifyAllExpectations();
