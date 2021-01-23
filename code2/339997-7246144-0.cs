    public IEnumerable<SelectListItem> ChangeMyName {  
    get {  
    foreach (string positionValue in Enum.GetNames(typeof(PlayerPosition)))
        {
            var selectListItem = new SelectListItem();
            selectListItem.Text = positionValue;
            selectListItem.Value = ((int)Enum.Parse(typeof(PlayerPosition), positionValue)).ToString();
            if (BasePlayerForm.Position.ToString() == positionValue)
                selectListItem.Selected = true;
            ChangeMyName.Add(selectListItem);
        }
    set{return;}  
    }  
