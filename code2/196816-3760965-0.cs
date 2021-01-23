    public List<Widget> GetWidgets(string cond1, string cond2, string cond3)
    {
        MyDataContext db = new MyDataContext();
        var widgets = db.Widgets;
    
        if(cond1 != null)
            widgets = widgets.Where(w => w.condition1 == cond1);
    
        if(cond2 != null)
            widgets = widgets.Where(w => w.condition2 == cond2);
    
        if(cond3 != null)
            widgets = widgets.Where(w => w.condition3 == cond3);
    
        return widgets.ToList();
    }
