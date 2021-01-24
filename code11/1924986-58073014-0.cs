object obj = new int[5];
var method = obj.GetType().GetMethod("get_Item", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
if (method != null)
{
    object inner_obj = method.Invoke(obj, new object[] { 0 });
}
