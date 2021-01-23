        public void InputValidText(List<IWebElement> inputList)
        {
            foreach (IWebElement element in inputList)
            {
                if (element.Displayed)
                {
                    if (element.GetAttribute("type") == "checkbox")
                    {
                        if (!element.Selected)
                        {
                            element.Click();
                        }
                    }
                    else if (element.TagName == "select")
                    {
                        if (element.GetAttribute("id") != "CreditCardYearExp")
                        {
                            SelectElement select = new SelectElement(element);
                            int options = element.FindElements(By.TagName("option")).Count();
                            select.SelectByIndex(new Random().Next(1, options - 1));
                        }
                        else
                        {
                            SelectElement select = new SelectElement(element);
                            int options = element.FindElements(By.TagName("option")).Count();
                            select.SelectByIndex(new Random().Next(3, options - 1));
                        }
                    }
                    else
                    {
                        string inputToValidate = element.GetAttribute("id").ToString();
                            element.Clear();
                            if (Enum.GetNames(typeof(NameInputValidation)).Contains(inputToValidate))
                            {
                                element.SendKeys(ValidContent.GeneralLongTextInput);
                            }
                            else if (Enum.GetNames(typeof(PostalCodeInputValidation)).Contains(inputToValidate))
                            {
                                element.SendKeys(ValidContent.PostalCode);
                            }
                            else if (Enum.GetNames(typeof(PhoneNumberInputValidation)).Contains(inputToValidate))
                            {
                                element.SendKeys(ValidContent.LongPhoneNumber);
                            }
                            else if (Enum.GetNames(typeof(EmailInputValidation)).Contains(inputToValidate))
                            {
                                element.SendKeys(ValidContent.NewEmail);
                            }
                            else if (Enum.GetNames(typeof(AddressInputValidation)).Contains(inputToValidate))
                            {
                                element.SendKeys(ValidContent.GeneralAddress);
                            }
                            else if (Enum.GetNames(typeof(PasswordInputValidation)).Contains(inputToValidate))
                            {
                                element.SendKeys(ValidContent.NewPassword);
                            }
                            else if (Enum.GetNames(typeof(TextAreaValidation)).Contains(inputToValidate))
                            {
                                element.SendKeys(ValidContent.GeneralTextAreaInput);
                            }
                            else if (inputToValidate == "CreditCardTextBox")
                            {
                                element.SendKeys(ValidContent.CreditCard);
                            }
                            else
                            {
                                element.SendKeys(ValidContent.GeneralShortTextInput);
                            }
                    }
                }
            }
        }
