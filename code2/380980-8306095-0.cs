    public static T FindControlByType<T>(this Control childCnt, string Id = "")
         where T: Control
    {
        return childCnt.Controls.OfType<T>()
                       .FirstOrDefault(item => string.IsNullOrEmpty(Id) || item.ID.Contains(Id));
    }
