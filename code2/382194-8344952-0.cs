            SelectList region1 = browser.SelectList(Find.ByName("mylist"));
            Dictionary<string, string> optionsdictionary = new Dictionary<string, string>();
            foreach (Option option in region1.Options)
            {
                optionsdictionary.Add(option.Value, option.Text);
            }
