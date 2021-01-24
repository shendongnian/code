    // Headers
    private void GetSetCustomHeaders(ref string theUsername, ref string thePassword, ref string theAPIKey)
    {
        try
        {
            foreach (KeyValuePair<string, IEnumerable<string>> header in this.Request.Headers)
            {
                string headerType = header.Key;
                string headerTypeUpperTrim = headerType.Trim().ToUpper();
                IEnumerable<string> headerValue = header.Value;
                string fullHeaderValue = "";
                bool isFirstHeaderValue = true;
                foreach (string headerValuePart in headerValue)
                {
                    if (isFirstHeaderValue)
                    {
                        fullHeaderValue = headerValuePart;
                        isFirstHeaderValue = false;
                    }
                    else
                    {
                        fullHeaderValue = fullHeaderValue + Environment.NewLine + headerValuePart;
                    }
                }
                if (headerTypeUpperTrim == "USERNAME")
                {
                    theUsername = fullHeaderValue;
                }
                else if (headerTypeUpperTrim == "PASSWORD")
                {
                    thePassword = fullHeaderValue;
                }
                else if (headerTypeUpperTrim == "APIKEY")
                {
                    theAPIKey = fullHeaderValue;
                }
            }
        }
        catch (Exception)
        {
            //MessageBox.Show("Error at 'GetSetCustomHeaders'" + Environment.NewLine + Environment.NewLine + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
