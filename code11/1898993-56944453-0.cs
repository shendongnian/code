    public class CustomCell : ViewCell
        {
            public event EventHandler OnToggled;
            public CustomCell()
            {
                Check check = new Check();
                ...
                check.Toggled += Check_Toggled;
            }
            private void Check_Toggled(object sender, EventArgs e)
            {
                OnToggled?.Invoke(sender, e);
            }
        }  
