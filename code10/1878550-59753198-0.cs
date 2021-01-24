     public class HybridWebView : WebView
    {
        Action<string> action;
        public static BindableProperty EvaluateJavascriptProperty =
        BindableProperty.Create(nameof(EvaluateJavascript), typeof(Func<string, Task<string>>), typeof(HybridWebView), null, BindingMode.OneWayToSource);
        public Func<string, Task<string>> EvaluateJavascript
        {
            get { return (Func<string, Task<string>>)GetValue(EvaluateJavascriptProperty); }
            set { SetValue(EvaluateJavascriptProperty, value); }
        }
        public void RegisterAction(Action<string> callback)
        {
            action = callback;
        }
        public void Cleanup()
        {
            action = null;
        }
        public void InvokeAction(string key)
        {
            if (action == null)
            {
                return;
            }
            action.Invoke(key);
        }
    }
