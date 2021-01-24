    // Interface to inject to repository
    public interface ICallMapper
    {
        CallVm Map(Call call);
    }
    public class CallMapper : ICallMapper
    {
        public CallVm Map(Call call)
        {
            return call == null ? null : new CallVm { Id = call.Id, UserFullname = call.User?.Username };
        }
    }
