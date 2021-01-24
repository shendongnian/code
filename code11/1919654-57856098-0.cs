    List<IWebElement> options = driver.FindElements(By.XPath("//*[@id='id_object']/option"));
    for (int i = 0; i < options.Count; i++)
        {
            comboBox1.Items.Add(options.ElementAt(i).Text + " , " + options.ElementAt(i).GetAttribute("value"));
        }
