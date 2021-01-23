    public class MyDropDownList : DropDownList
        {
            public MyDropDownList()
            {
            }
    
            public string CustomProperty
            {
                get;
                set;
            }
    
            public string SelectedCustomProperty
            {
                get
                {
                    //Use the SelectedIndex to retrieve the right element from ViewState
                    return ViewState["CustomProperty" + this.SelectedIndex] as string;
                }
            }
    
            protected override void OnPreRender(EventArgs e)
            {
                base.OnPreRender(e);
                int i = 0;
                if (this.DataSource != null)
                {
                    foreach (var item in this.DataSource as IEnumerable)
                    {
                        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(item);
                        PropertyDescriptor pd = properties.Find(CustomProperty, true);
                        this.Items[i].Attributes.Add(CustomProperty, pd.GetValue(item).ToString());
                        //We need to save the CustomProperty value on ViewState if we want to be able to retrieve it...
                        ViewState["CustomProperty" + i] = pd.GetValue(item).ToString();
                        i++;
                    }
                }
            }
        }
