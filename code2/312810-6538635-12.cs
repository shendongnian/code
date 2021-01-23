    class Handler : IHandler<IMsg> 
    {
        public void Notify(IMsg msg)
        {
        }
    }
    ...
    Action<SMsg> action = Pub<SMsg>.DoIt(new Handler());
    action(default(SMsg));
