    public static IEnumerable<T> FindControlsByType<T>(this Control childCnt, string Id = "")
    	where T : Control
    {
    	var controls = childCnt.Controls.OfType<T>();
    	
    	return Id == "" ? controls : controls.Where(c => c.ID.Contains(Id));
    }
