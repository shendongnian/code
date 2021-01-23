    public class ImprovedComboBox : ComboBox
    {
        public ImprovedComboBox()
        {
            
        }
        public object DataSource
        {
            get { return base.DataSource; }
            set { base.DataSource = value; DetermineDropDownWidth(); }
        }
        public string DisplayMember
        {
            get { return base.DisplayMember; }
            set { base.DisplayMember = value; DetermineDropDownWidth(); }
        }
        public string ValueMember
        {
            get { return base.ValueMember; }
            set { base.ValueMember = value; DetermineDropDownWidth(); }
        }
        private void DetermineDropDownWidth()
        {
            
            int widestStringInPixels = 0;
            foreach (Object o in Items)
            {
                string toCheck;
                PropertyInfo pinfo;
                Type objectType = o.GetType();
                if (this.DisplayMember.CompareTo("") == 0)
                {
                    toCheck = o.ToString();
                }
                else
                {
                    pinfo = objectType.GetProperty(this.DisplayMember);
                    toCheck = pinfo.GetValue(o, null).ToString();
                }
                if (TextRenderer.MeasureText(toCheck, this.Font).Width > widestStringInPixels)
                    widestStringInPixels = TextRenderer.MeasureText(toCheck, this.Font).Width;
            }
            this.DropDownWidth = widestStringInPixels + 15;
        }
    }
