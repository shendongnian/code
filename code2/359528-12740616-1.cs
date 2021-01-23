    public class UIAdobeAcrobatProWindow : WinWindow
    {        
        public UIAdobeAcrobatProWindow()
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.Name, "Adobe Acrobat Pro", PropertyExpressionOperator.Contains));
            **this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);**
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "AcrobatSDIWindow";
            #endregion
        }
    }
