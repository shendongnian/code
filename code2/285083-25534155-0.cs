    bool MyProp
    {
        public get;
        private set;
    }
    
    int MyProp_AsInt
    {
        private get;
        public set
        {
            MyProp = (value > 0) ? true : false;
        }
    }
