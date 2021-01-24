menuBusiness.GetMenuList()
AS list, and when you send it in OK() function JSON looks like:
{
     menuList: System.Collections.Generic.List`1
}
So if you want to serialize array like that, you should try Newtonsoft.Json
var list = JsonConvert.SerializeObject(menuBusiness.GetMenuList());
return OK(list);
but it will display like ['item1', 'item2']
