    void SendSingleMessage(int request, out GetConfigurationSettingMessageResponse<object> obj)
    {
        if (obj.InnerObject is Class1)
        {...}
        else if...
    ..
    }
...
       class GetConfigurationSettingMessageResponse<T>
        {
            public T _innerObject { get; set; }
        }
