     public static string GetTextClipboard()
        {
            string txtReturn = null;
            Thread staThread = new Thread(
                delegate ()
                {
                    try
                    {
                        txtReturn = Clipboard.GetText();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
            return txtReturn;
        }
