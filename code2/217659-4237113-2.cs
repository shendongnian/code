     delegate void valueDelegate(string value);
    
        private void SetValue(string value)
        {   
            if (someControl.InvokeRequired)
            {
                someControl.Invoke(new valueDelegate(SetValue),value);
            }
            else
            {
                someControl.Text = value;
            }
        }
