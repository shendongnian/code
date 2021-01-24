    class MockErrorChecker:MyErrorChecker
    {
        public bool Called{get;private set;}
        public override void ForceExit()
        {
            Called=true;
        }
    }
