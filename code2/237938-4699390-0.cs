    public class XComboBox : ComboBox 
    { 
        private BindingExpression bE; 
        public XComboBox() 
        { 
            this.SelectionChanged += new SelectionChangedEventHandler(XComboBox_SelectionChanged); 
        } 
        void XComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        { 
            if (bE==null) 
            { 
             bE = this.GetBindingExpression(ComboBox.SelectedValueProperty); 
            } 
            else 
            { 
                if (this.GetBindingExpression(ComboBox.SelectedValueProperty) == null) 
                { 
                 this.SetBinding(ComboBox.SelectedValueProperty, bE.ParentBinding);     
                } 
            } 
        } 
    }
