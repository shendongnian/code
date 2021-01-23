    namespace Test
    {
        public enum MYENUM
        {
            One,
            Two
        }
    }
    
    <% Response.Write(Test.MYENUM.One.ToString()); %>
