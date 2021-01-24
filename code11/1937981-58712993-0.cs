    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    namespace WinAppDriver
    {
        class SpinControl
        {
            public int Value {
                get
                {
                    //call _textBox here to get the value from your control.
                    return 0;
                }
            }
        private readonly AppiumWebElement _increaseButton;
        private readonly AppiumWebElement _decreaseButton;
        private readonly AppiumWebElement _textBox;
        public SpinControl(string automationID, WindowsDriver<WindowsElement> Driver)
        {
            WindowsElement customControl = Driver.FindElementByAccessibilityId(automationID);
            ReadOnlyCollection<AppiumWebElement> customControlChildren = customControl.FindElementsByXPath(".//*");
            _increaseButton = customControlChildren.First(e => e.FindElementByAccessibilityId("Part_IncreaseButton").Id == "Part_IncreaseButton");
            _decreaseButton = customControlChildren.First(e => e.FindElementByAccessibilityId("Part_DecreaseButton").Id == "Part_DecreaseButton");
            _textBox = customControlChildren.First(e => e != _increaseButton && e != _decreaseButton);
        }
        public void Increase()
        {
            //call _increaseButton here
        }
        public void Decrease()
        {
            //call _decreaseButton here
        }
        public void Input(int number)
        {
            //call _textBox here
        }
    }
