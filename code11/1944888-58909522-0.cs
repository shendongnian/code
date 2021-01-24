    private void Button_Clicked(object sender, EventArgs e)
    {
        TabBar bar = Shell.Current.Items[0] as TabBar;
        //Select the first Tab
        bar.CurrentItem = bar.Items[0];
        //If you want to select the second tab, you can use bar.CurrentItem = bar.Items[1]; the same as the third tab, the fourth tab......
    }
