    class FakeTerminator:ITerminator
    {
        public bool Called{get;private set;}
        public void Exit()
        {
            Called=true;
        }
    }
