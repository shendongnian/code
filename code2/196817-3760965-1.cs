    public IEnumerable<Widget> GetWidgets(string cond1, string cond2, string cond3)
    {
        MyDataContext db = new MyDataContext();
        var widgets = db.Widgets;
    
        if(cond1 != null)
            widgets = widgets.Where(w => w.condition1 == cond1);
    
       // [...]
    
        return widgets;
    }
