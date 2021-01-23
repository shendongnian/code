    class LayoutsEngine 
    {
        internal static void ThreadSafeDoer(Form Form, Delegate Whattodo)
        {
            if (!Form.IsDisposed)
            {
                if (Form.InvokeRequired)
                {
                    Form.Invoke(Whattodo);
                }
                else
                {
                    Whattodo.DynamicInvoke();
                }
            }
        }
    }
