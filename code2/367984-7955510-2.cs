        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else this.label1.Text = text;
        } 
        void SomeMethod()
        {
            SetText(yourVariable.ToString());
        }
