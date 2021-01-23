        public bool ShowDialog(string msg)
        {
            if (_parent == null)
                return false;
            // set the label
            msgLbl.Text = msg;
            // disable the form
            ParentEnabled(false);
            // make the dialog visible
            Visible = true;
            // wait for the user to click a button
            _clicked = false;
            while (!_clicked)
            {
                Thread.Sleep(20);
                Application.DoEvents();
            }
            // reenable the form
            ParentEnabled(true);
            // hide the dialog 
            Visible = false;
            // return the result
            return _result;
        }
