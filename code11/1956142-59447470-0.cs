    public class MessageA { }
    public class MessageB { }
    public interface IService<TMessage> { }
    public class ServiceA : IService<MessageA> { }
    public class ServiceB : IService<MessageB> { }
