    public class MoqProvider<T> : Provider<T> // T is the desired service
    {
        protected override T CreateInstance(IContext context)
        {
            return new Mock<T>().Object;
        }
    }
