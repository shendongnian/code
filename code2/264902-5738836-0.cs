      public void InvokeMethod(string methodName)
        {
            var reflectOb = new GCS_WebService();
            Impromptu.InvokeMemberAction(reflectOb, methodName)
        }
