    interface IAct
    {
        bool CanAct();
    }
    class Act1 : IAct
    {
        public bool CanAct()
        {
            return true;
        }
    }
    class Act2 : IAct
    {
        public bool CanAct()
        {
            return false;
        }
    }
    class ComplexAction : IAct
    {
        private Act1 action1;
        private Act2 action2;
        
        public ComplexAction(Act1 action1, Act2 action2)
        {
            this.action1 = action1;
            this.action2 = action2;
        }
        public bool CanAct()
        {
            return action1.CanAct() && action2.CanAct();
        }
    }
