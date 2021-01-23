    private void button1_Click(object sender, System.EventArgs e)
    {
        //listBox1 is the object containing the collection.  Remember, if the collection
        //belongs to the class you're editing, you can use this
        //Items is the name of the property that is the collection you wish to edit.
        PropertyDescriptor pd = TypeDescriptor.GetProperties(listBox1)["Items"];
        UITypeEditor editor = (UITypeEditor)pd.GetEditor(typeof(UITypeEditor));
        RuntimeServiceProvider serviceProvider = new RuntimeServiceProvider();
        editor.EditValue(serviceProvider, serviceProvider, listBox1.Items);
    }
