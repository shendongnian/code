    public class MyClass : IronPython.Runtime.IPythonMembersList
    {
        public void some_func(string s1, string s2) { }
        IList<object> IronPython.Runtime.IPythonMembersList.GetMemberNames(CodeContext context)
        {
            return new[] { "some_func" };
        }
        IList<string> Microsoft.Scripting.Runtime.IMembersList.GetMemberNames()
        {
            return new[] { "some_func" };
        }
    }
