    public interface IPluginHost
    {
        void DoMethod(string MethodName);
    }
    public partial MyForm:Form, IPluginHost
    {
        #region IPluginHost implementation
        public void DoMethod(string MethodName)
        {
             switch (MethodName)
                 case "SayHello":
                     SayHello();
                     break;
                 ...
        }
        #endregion
    }
