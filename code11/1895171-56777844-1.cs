    using Atata;
    using OpenQA.Selenium;
    
    namespace Chat.UITests
    {
        using _ = MainPage;
    
        public class MainPage : Page<_>
        {
            [FindFirst]
            public TextInput<_> Message { get; private set; }
    
            [FindByClass("send-button")]
            public Button<_> Send { get; private set; }
    
            public _ EnterAs(string name)
            {
                IAlert alert = Driver.SwitchTo().Alert();
                alert.SendKeys(name);
                alert.Accept();
    
                Driver.SwitchTo().DefaultContent();
    
                return Owner;
            }
        }
    }
