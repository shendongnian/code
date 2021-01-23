			try
			{
            if (webBrowser1.DocumentText.IndexOf("Negative Orders") != -1)
            {
              webBrowser1.Navigate(@"http://............somepage");
				while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
				{
					Application.DoEvents();
				}
	
				MessageBox.Show("finished loading");
            }
			catch (Exception x)
			{
				System.Diagnostics.Debugger.Break();
			}
         }
`
