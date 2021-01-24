    public void CloseNotepad()
    {
        IntPtr hWnd = IntPtr.Zero;
        using (Process p = Process.GetProcessesByName("notepad").FirstOrDefault()) {
            hWnd = p.MainWindowHandle;
        }
        if (hWnd == IntPtr.Zero) return;
        var window = GetMainWindowElement(hWnd);
        var menuBar = GetWindowMenuBarElement(window);
        var fileMenu = GetMenuBarMenuByName(menuBar, "File");
        if (fileMenu is null) return;
        // var fileSubMenus = GetMenuSubMenuList(fileMenu);
        bool result = InvokeSubMenuItemByName(fileMenu, "Exit", true);
    }
    private AutomationElement GetMainWindowElement(IntPtr hWnd) 
        => AutomationElement.FromHandle(hWnd) as AutomationElement;
    private AutomationElement GetWindowMenuBarElement(AutomationElement window)
    {
        var condMenuBar = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuBar);
        var menuBar = window.FindAll(TreeScope.Descendants, condMenuBar)
            .OfType<AutomationElement>().FirstOrDefault(ui => !ui.Current.Name.Contains("System"));
        return menuBar;
    }
    private AutomationElement GetMenuBarMenuByName(AutomationElement menuBar, string menuName)
    {
        var condition = new AndCondition(
            new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem),
            new PropertyCondition(AutomationElement.NameProperty, menuName)
        );
        if (menuBar.Current.ControlType != ControlType.MenuBar) return null;
        var menuItem = menuBar.FindFirst(TreeScope.Children, condition);
        return menuItem;
    }
    private List<AutomationElement> GetMenuSubMenuList(AutomationElement menu)
    {
        if (menu.Current.ControlType != ControlType.MenuItem) return null;
        ExpandMenu(menu);
        var submenus = new List<AutomationElement>();
        submenus.AddRange(menu.FindAll(TreeScope.Descendants,
            new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem))
                                                   .OfType<AutomationElement>().ToArray());
        return submenus;
    }
    private bool InvokeSubMenuItemByName(AutomationElement menuItem, string menuName, bool exactMatch)
    {
        var subMenus = GetMenuSubMenuList(menuItem);
        AutomationElement namedMenu = null;
        if (exactMatch) {
            namedMenu = subMenus.FirstOrDefault(elm => elm.Current.Name.Equals(menuName));
        }
        else {
            namedMenu = subMenus.FirstOrDefault(elm => elm.Current.Name.Contains(menuName));
        }
        if (namedMenu is null) return false;
        InvokeMenu(namedMenu);
        return true;
    }
    private void ExpandMenu(AutomationElement menu)
    {
        if (menu.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out object pattern))
        {
            (pattern as ExpandCollapsePattern).Expand();
        }
    }
    private void InvokeMenu(AutomationElement menu)
    {
        if (menu.TryGetCurrentPattern(InvokePattern.Pattern, out object pattern))
        {
            (pattern as InvokePattern).Invoke();
        }
    }
