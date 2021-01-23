    public static class MessageBoxUtilities
    {
        public static DialogResult Show(MessageBoxParameters p)
        {
            return MessageBox.Show(p.Text, p.Caption, p.Buttons, p.Icon);
        }
    }   
