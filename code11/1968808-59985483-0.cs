cs
    public class AACSCaller 
    {
        3rdPartySystem1 _system1;
        3rdPartySystem2 _system2;
        public AACSCaller(Settings appSettings)
        {
            _appSettings = appSettings;
            if (appSettings.system1Enabled)
            {
                _system1 = new 3rdPartySystem1();
            }
            if (appSettings.system2Enabled)
            {
                _system2 = new 3rdPartySystem2();
            }
        }
        public void Method1()
        {            
            _system1?.Method1();
            _system2?.Method1();
        }
        public void Method2()
        {            
            _system1?.Method2();            
            _system2?.Method2();
        }
    }
Another option is define an interface or base class for `3rdPartySystem1` and `3rdPartySystem2`, store them in collection and call a required methods for every item in collection
