    public static void ClickRadioButton()
    {
        var count = Driver.Instance.FindElements(By.Name("radiobutton"));
        foreach(var item in count) 
        {
            string radioButtonName = item.Text; //or TagName or what you want.
            if(radioButtonName == "radio3")
            {
                item.Click();
            }
        }
    }
