class SecondaryClass
{
    public MyObject parameter = new MyObject("key", 0);
    public List<MyObject> list = new List<MyObject>();
    public SecondaryClass()
    {
        list.Add(parameter);
    }
    public UpdateParameter(MyObject newParameter, string key) 
    {
        // here you can write code that can *directly* access your field or list.
        // you can, for instance, search for the object by key in the list, delete it from the list, and add `newParameter` to the list
        // and reassign "parameter" with this new object.
    }
}
Note that you can now defer the burden of searching if the key exist in this "UpdateParameter" method.
Note : I don't understand the idea of using a "list" of parameters, additionally to having a field storing a single parameter.
As suggested, if you  have several key-value pairs, you should use a `Dictionary<string, MyObject>` as an internal field of your MainClass and SecondaryClass, that would simplify access and readability of your code a lot.
