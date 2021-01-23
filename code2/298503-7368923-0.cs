    interface ICallbackInterface
    {
        void CallbackFxn();
    }
    [Serializable]
    public class MyCustomHost : ITextTemplatingEngineHost, ITextTemplatingSessionHost, IStencilFileRecordManagement
    {
        private ICallbackInterface callback = null;
        public MyCustomHost(ICallbackInterface cb)
        {
            callback = cb;
        }
        public void CallbackFxn()
        {
            callback.CallbackFxn();
        }
    }
    public abstract class MyTemplateBase : TextTransformation
    {
        public virtual MyCustomHost CustomHost
        {
            get
            {
                dynamic metame = this;
                MyCustomHost rval = null;
                try
                {
                    /// <summary>
                    /// The "Host" property will be added to the generated class by the T4 environment whenever a 
                    /// "hostspecific" template is processed. 
                    /// </summary>
                    rval = metame.Host as MyCustomHost;
                }
                catch (RuntimeBinderException e)
                {
                    logger.ErrorException(
                        "Received the following exception while processing a stencil template", e);
                }
                return rval;
            }
        }
    }
