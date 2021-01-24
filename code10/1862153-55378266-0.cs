        private void btnSendKey_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
            Thread.Sleep(50);
            
            SendKeys.Send("abcd".ToUpper().Trim());
            Thread.Sleep(50);
            //it will send tab key to focus next textbox
            SendKeys.Send("{TAB}");
            Thread.Sleep(50);
            SendKeys.Send("efgh".ToUpper().Trim());
            //send tab to get focus on button
            SendKeys.Send("{TAB}");
            // it will send key "Enter" for mouse click
            SendKeys.Send("{ENTER}");
        }
