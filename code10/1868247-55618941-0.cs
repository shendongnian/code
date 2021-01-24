public Automat(StatefulServiceContext context)
        : base(context)
{
    var ok = this.StateManager.TryAddStateSerializer(new DeviceStateSerializer());
    if (!ok)
    {
        Log.FailedToRegisterStateSerializer();
    }
}
