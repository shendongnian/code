    struct SMsg : IMsg { public int a, b, c, x, y, z; }
    class Handler : IHandler<IMsg> 
    {
        public void Notify(IMsg msg)
        {
        }
    }
    ...
    Action<SMsg> action = Pub<SMsg>.DoIt(new Handler());
    action(default(SMsg));
