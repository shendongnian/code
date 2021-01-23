    public HttpContextLifetimeManager()
    {
        HttpContext.Current.ApplicationInstance.EndRequest += (sender, e) => {
            Dispose();
        };
    }
    public override void RemoveValue()
    {
        var value = GetValue();
        IDisposable disposableValue = value as IDisposable;
        if (disposableValue != null) {
            disposableValue.Dispose();
        }
        HttpContext.Current.Items.Remove(ItemName);
    }
    public void Dispose()
    {
        RemoveValue();
    }
