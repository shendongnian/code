    [Description("The items in the UserControl's ComboBox."), 
     DesignerSerializationVisibility(DesignerSerializationVisibility.Content), 
     Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
    public System.Windows.Forms.ComboBox.ObjectCollection MyItems {
        get { 
            return comboBox1.Items; 
        }
    }
