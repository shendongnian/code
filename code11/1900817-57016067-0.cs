if(items.SelectedItem== null)
{
     item.BList.Add(AllList.Where(x => x.Id == id).FirstOrDefault());
     item.Blist = item.Blist.Where(item => item != null);
     return;
}
`
If you are looking for solution to check list contains any `null` value, then you can use `Any()` 
    var isNullValueExist = item.Blist.Any(x => x == null); //This will return boolean value based on predicate
