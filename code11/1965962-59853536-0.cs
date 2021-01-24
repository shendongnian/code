public bool SaveRoleModule(RoleModel role)
{
    PropertyInfo[] properties = typeof(RoleModel).GetProperties();
    foreach (PropertyInfo property in properties)
    {
       if(property.Name != "ID" && property.Name != "RoleName")
       {
          var value = GetPropValue(role, property.Name);
          Console.WriteLine(value);//(this doesn't work) I want it dynamic
          Console.WriteLine(role.TrackAndTrace); //not like this
       }
    }
    return true;
}
public static object GetPropValue(object src, string propName)
{
     return src.GetType().GetProperty(propName).GetValue(src, null);
}
