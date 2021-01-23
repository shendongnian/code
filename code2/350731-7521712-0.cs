    public new void Remove()
    {
        XElement parent = this.Parent;
        base.Remove();
    
        if ((parent != null) && (parent.GetType() == typeof(TreeElement)))
        {
    	//need to tell parent that they are losing an element
    	((TreeElement)parent).NotifyPropertyChanged("Elements");
        }
    }
    
    
    public new void Add(object Content)
    {
        base.Add(Content);
        NotifyPropertyChanged("Elements");
    }
