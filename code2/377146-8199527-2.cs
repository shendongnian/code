    public class MyDropDownList : DropDownList
    {
        public MyDropDownList()
        {   
        }
    
        public string CustomProperty { get; set; }
    
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int i = 0;
            foreach (var item in this.DataSource as IEnumerable)
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(item);
                PropertyDescriptor pd = properties.Find(CustomProperty, true);
                this.Items[i].Attributes.Add(CustomProperty, pd.GetValue(item).ToString());
                i++;
            }          
        }
    }
