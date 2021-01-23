    for (int i = 1; i < numOfLanguages; i++)
    {
         // add a tab for each language
         string tabTitle = split[i];
         TabPage newTab = new TabPage(tabTitle);
         newTab.Name = tabTitle;
         languageTabs.TabPages.Add(newTab);
    }
    ...
    languageTabs.TabPages[split[i]].Controls.Add(new Button());
