    public class MessageBox
    {
        private IMessageBoxContainer container = null;
    
        public MessageBox(IMessageBoxContainer _container)
        {
            container = _container;
        }
    
        public void Show(string message)
        {
            container.Label.Text = message;
            container.UpdatePanel.Update();
        }
    }
