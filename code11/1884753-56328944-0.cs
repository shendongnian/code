var list = new List<object>();
list.Add("Hello");
list.Add(5);
list.Add(MyImage);
foreach (object obj in list) 
{
    if (obj is string) 
    {
        Debug.Log(obj.ToString());
    }
}
