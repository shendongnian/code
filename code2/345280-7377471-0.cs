    List<object> list = new List<object>();
    list.Add("test");
    list.Add("test1");
    
    BindingList<object> bindingList;
    bindingList = new BindingList<object>(list);            
    
    listBox1.DataSource = bindingList;
    
    bindingList.Remove("test");
