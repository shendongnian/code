    public class DevicePopup
    {
        ContextMenuStrip    m_popup;
        public DevicePopup(BindingContext bindingContext)
        {
            m_popup = new ContextMenuStrip();
            m_popup.BindingContext = bindingContext;
    
            . . .
        }
        public ToolStripTextBox AddTextBox(object dataSource, string dataProperty)
        {
          ToolStripTextBox textBox = new ToolStripTextBox();
          textBox.Control.CreateControl();
          textBox.TextBox.DataBindings.Add("Text", dataSource, dataProperty);
        
          . . . 
          return textBox;
        }
    }
