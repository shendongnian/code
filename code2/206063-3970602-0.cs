    public class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            AutoCompleteMode = AutoCompleteMode.None;
            AutoCompleteSource = AutoCompleteSource.None;
        }
    
        [DefaultValue(ComboBoxStyle.DropDownList)]
        public new ComboBoxStyle DropDownStyle
        {
            get { return base.DropDownStyle; }
            set { base.DropDownStyle = value; }
        }
    
        [DefaultValue(AutoCompleteMode.None)]
        public new AutoCompleteMode AutoCompleteMode
        {
            get { return base.AutoCompleteMode; }
            set 
            {
                if (value != AutoCompleteMode.None)
                    base.DropDownStyle = ComboBoxStyle.DropDown;
    
                base.AutoCompleteMode = value; 
            }
        }
        [DefaultValue(AutoCompleteSource.None)]
        public new AutoCompleteSource AutoCompleteSource
        {
            get { return base.AutoCompleteSource; }
            set 
            {
                if (value != AutoCompleteSource.None)
                    base.DropDownStyle = ComboBoxStyle.DropDown;
    
                base.AutoCompleteSource = value; 
            }
        }
    }
