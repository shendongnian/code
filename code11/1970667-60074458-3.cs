    public class CallRepository : ICallRepository
    {
        private readonly ICallMapper _callMapper;
        public CallRepository(ICallMapper callMapper)
        {
            _callMapper = callMapper;
        }
        public IList<CallVm> GetList()
        {
            // Call DB and get entities
            var calls = GetCalls();
            // Map DB entities to plain model
            return calls.Select(_callMapper.Map).ToList();
        }
    }
