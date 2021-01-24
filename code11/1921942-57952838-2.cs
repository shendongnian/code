    var orgs = _context.Org.ToArray();
    foreach(var item in orgs)
    {
       //code here
2. You don't add items into your data list inside foreach loop. You can do it like so
    var tmpOrg = new Org() { code code code} ;
    data.Add(tmpOrg);
3. This predicate statement in where() clause doesnt make sense to me. You check if the id has value but that's the primary key (I suppose otherwise its extremaly confusing) so that can't be null. IMHO you can remove that clause. 
4. **This whole thing can be simplified into one expression.** You don't need to materialize the whole table and you don't need that foreach loop. You can change the result expression to use _context.Org intead of data. Remove the where clause as it is not needed and in the Select clause on hasChildren you can just change this line
    hasChildren = item.ParentID == null ? true : false;
**EDIT**
What you should be left with is 
public IActionResult OnGetRead(int? id)
{       
    var result = _context.Org.Select(item => new 
            {
                OrgID = item.ID,
                Org = item.OrgName,
                HasChildren = item.ParentID == null ? true : false;
            });
     
    return new JsonResult(result);       
}
