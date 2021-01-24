c#
public interface IUnknownTypeDeviceParameter
{
    event EventHandler<Exception> ParameterNotSet;
    string ParameterName { get; }
    string ParameterValue { get; }
    string ParameterUnit { get; }
    bool IsReadOnly { get; }
}
public interface IDeviceParameter<T> : IUnknownTypeDeviceParameter
{
    event EventHandler<IDeviceParameter<T>> ParameterValueChanged;
    event EventHandler<Exception> ParameterNotSet;
    string ParameterName { get; }
    string ParameterValue { get; }
    string ParameterUnit { get; }
    bool IsReadOnly { get; }
    T Parameter { get; }
    void SetParameter(T value);
}
If you would like to use one of the functions in `IDeviceParameter<T>` on an `IUnknownTypeDeviceParameter` you would need to cast it back to an `IDeviceParameter<T>`.
