    public static T FindControlByType<T>(this Control childCnt, string id = "") 
        where T : Control
    { 
        foreach (Control item in childCnt.Controls) 
        { 
            if (item is T && ((id == "" || item.ID.Contains(id)))
            { 
                return (T)item; 
            } 
        } 
 
        return default(T);
 
    } 
