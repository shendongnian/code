    public event EventHandler<UpdateListBoxEventArgs> UpdateListBox;     
          converter.UpdateListBox += 
     new EventHandler<CVEConverter.UpdateListBoxEventArgs>(AddToListBox);       
     public class UpdateListBoxEventArgs : EventArgs
        {
            private readonly string lbTerminalText;
            public UpdateListBoxEventArgs(string lbText)
            {
                this.lbTerminalText = lbText;
            }
            public string lbTerminalWindowText
            {
                get { return lbTerminalText; }
            }
        }
