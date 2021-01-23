    public static class IWebElementExtensions
        /// <summary>
        /// Selects an option in a dropdown list by visible option text.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="optionText"></param>
        public static void SelectOptionByText(this IWebElement element, string optionText)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if (element.TagName != "select")
                throw new ArgumentException("The element must be a <select> tag");
            if (optionText == null)
                throw new ArgumentNullException("optionText");
            var options = element.FindElements(By.TagName("option"))
                                 .Where(opt => opt.Text == optionText);
            if (options.Count() == 0)
                throw new NoSuchElementException("Could not find <option>" + optionText + "</option> inside <select id=\"" + element.GetAttribute("id") + "\">");
            if (options.Count() > 1)
                throw new WebDriverException("Too many <option>" + optionText + "</option> tags inside <select id=\"" + element.GetAttribute("id") + "\">");
            element.Click();
            options.Single().Click();
        }
    }
