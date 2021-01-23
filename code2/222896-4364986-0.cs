    public string SomeProperty
        {
            get
            {
                StackTrace st = new StackTrace();
                StackFrame[] fr = st.GetFrames();
                if (fr != null)
                {
                    var propName = fr[0].GetMethod().Name.Substring(3, fr[0].GetMethod().Name.Length);
                    return "<" + propName + ">";
                }
                return "SomeProperty";
                
            }
        } 
