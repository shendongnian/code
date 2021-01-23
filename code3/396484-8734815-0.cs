    public void GetMethod(string methodName){
               
                var args = new Object[] { [INSERT ARGS IF NECESSARY] };
                try
                {
                    var t = new [INSERT NAME OF CLASS THAT CONTAINS YOUR METHOD]();
                    Type typeInfo = t.GetType();
                    var result = typeInfo.InvokeMember(methodName, BindingFlags.InvokeMethod, null, t, args);
                    return result;
                }
                catch (Exception ex)
                {
                    return ex;
                }
    }
