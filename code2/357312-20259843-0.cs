            string PlainText = null;
            try
            {
                if (!String.IsNullOrEmpty(RtfScript))
                {
                    using (RichTextBox richTxtBox = new RichTextBox())
                    {
                        richTxtBox.Rtf = RtfScript;
                        PlainText = richTxtBox.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                // log error here
            }
            finally
            {
                RtfScript = null;
            }
            return PlainText;
        }
