    public static DependencyProperty DisplayTemplateProperty = DependencyProperty.Register("DisplayTemplate", typeof(DataTemplate), typeof(myAutoComplete), null);
    public DataTemplate DisplayTemplate {
    	get { return myACB.ItemTemplate; }
    	set { myACB.ItemTemplate = value; }
    }
