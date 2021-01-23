    class Bar : IBar<IMsg> 
    {
        public void M(IMsg msg)
        {
        }
    }
    ...
    Action<SMsg> action = Pub<SMsg>.DoIt(new Bar());
    action(default(SMsg));
