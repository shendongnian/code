    public bool IsNotDisplayed(WindowsElement element)
        {
            try
            {
                element.Displayed;
                
            }
            catch (Exception)
            {
                return false;
            }
            return element.Displayed;
        }
