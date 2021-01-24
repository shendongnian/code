    class Invoke
    {
        public string InvokeMember(string method, string para)
        {
            try
            {
                string Result = (string)typeof(Invoke).InvokeMember(method, BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase
                                        | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
                                        null, this, new Object[] { para });
                return Result;
            }
            catch (MissingMemberException e)
            {
                MessageBox.Show("Unable to access the testMethod field: {0}", e.Message);
                return null;
            }
        }
    
        public void testMethod(string tri)
        {
            MessageBox.Show("methodInvoked - {0}", tri);
        }
    
    
    }
