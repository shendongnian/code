    public class UIItemWindow : WinWindow
            {
                //Use this button for UI Messages window
                public UIItemWindow()
                {
                    #region Search Criteria
                    this.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName,"Messages (4)DropDown");
                    this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
                    #endregion
                }
    
                #region Properties
                public WinMenuItem UITextMessages4MenuItem
                {
                    get
                    {
                        if ((this.mUITextMessages4MenuItem == null))
                        {
                            this.mUITextMessages4MenuItem = new WinMenuItem(this);
                            #region Search Criteria
                            this.mUITextMessages4MenuItem.SearchProperties.Add(WinMenuItem.PropertyNames.Name,"Text Messages (4)");
                            #endregion
                        }
                        return this.mUITextMessages4MenuItem;
                    }
                }
