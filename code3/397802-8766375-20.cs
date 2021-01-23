    class YellowDbConnectionFactory : OrmLiteConnectionFactory,
        IYellowDbConnectionFactory
    {
        public YellowDbConnectionFactory(string s) : base(s){}
    }
    class PurpleDbConnectionFactory : OrmLiteConnectionFactory,
        IPurpleDbConnectionFactory 
    {
        public YellowDbConnectionFactory(string s) : base(s){}
    }
