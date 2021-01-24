    public override void ChannelRead(IChannelHandlerContext context, object message)
    {
        LogDebug(context, "Read");
        base.ChannelRead(context, message);
    }
    
    public override async Task WriteAsync(IChannelHandlerContext context, object message)
    {
        LogDebug(context, "Write");
        await base.WriteAsync(context, message).ConfigureAwait(false);
    }
    private void LogDebug(IChannelHandlerContext context, string mesage)
    {
        var deviceInfo = context.Channel.GetAttribute(ProcessHandler.DeviceInfo).Get();
        if (deviceInfo != null)
           _logger.WithProperty("FlowMeterSerial", deviceInfo.Serial).Debug(message);
        else
           _logger.Debug(mesage);
    }
