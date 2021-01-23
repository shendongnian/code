    class Foo
    {
        int namedField = 1;
        string vari = "namedField"
    
        void AccessField()
        {
            int val = (int) GetType().InvokeMember(vari,
            BindingFlags.Instance | BindingFlags.NonPublic |
            BindingFlags.GetField, null, this, null);
            // now you should have 1 in val.
        }
    }
