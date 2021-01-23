    private void GetAllChildren(UITestControl uiTestControl, Microsoft.VisualStudio.TestTools.UITest.Common.UIMap.UIMap map)
    {
      foreach (UITestControl child in uiTestControl.GetChildren())
      {
          IUITechnologyElement tElem=(IUITechnologyElement)child.GetProperty(UITestControl.PropertyNames.UITechnologyElement);
          if (!map.Contains(tElem))
          {
              map.AddUIObject();
              GetAllChildren(child, map);    
          }
      }    
    }
