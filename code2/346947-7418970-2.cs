    public void deleteClick(sender, args){
        var deleteme = people.Where(p => p.IsSelected).ToList();
        
        DoDeleteLogicInDB(deleteme);
        deleteme.ForEach(p => people.Remove(p));
        //remove it from the observablecollection, and the view will automatically update.
    }
