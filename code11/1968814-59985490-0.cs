    public class AACSCaller 
    {
        IThirdPartySystem ThirdPartySystem;
        public AACSCaller(Settings appSettings)
        {
            _appSettings = appSettings;
            ThirdPartySystem = appSettings.system1Enabled ? new ThirdPartySystem1() : new ThirdPartySystem2();
           
        }
        public void Method1() => ThirdPartySystem.Method1();
        public void Method2() => ThirdPartySystem.Method2();
    }
    public interface IThirdPartySystem
    {
        void Method1();
        void Method2();
    }
    public class ThirdPartySystem1 : IThirdPartySystem
    {
        public void Method1()
        {
            //code here..
        }
    
        public void Method2()
        {
            //code here..
        }
    }
    public class ThirdPartySystem2 : IThirdPartySystem
        {
            public void Method1()
            {
                //code here..
            }
        
            public void Method2()
            {
                //code here..
            }
        }
