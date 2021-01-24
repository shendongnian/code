public Startup()
{
    LoggingConfiguration config = new LoggingConfiguration();
    var mailTarget = new MailTarget("mandrill")
    {
        Html = true,
        AddNewLines = true,
        ReplaceNewlineWithBrTagInHtml = true,
        Subject = "Test...",
        To = "-----",
        From = "john@doe.com",
        Body = "Message: ${message}${newline}${newline}Date: ${date}${newline}${newline}Exception: ${exception:format=tostring}${newline}${newline}",
        SmtpUserName = "-----",
        SmtpPassword = "-----",
        SmtpAuthentication = SmtpAuthenticationMode.Basic,
        SmtpServer = "-----",
        SmtpPort = 587
    };
    var bufferedMailTarget = new BufferingTargetWrapper("bufferedMandril", mailTarget)
    {
        SlidingTimeout = false,
        BufferSize = 100,
        FlushTimeout = 10000
    };
    config.AddTarget(bufferedMailTarget);
    var mailRule = new LoggingRule("*", NLog.LogLevel.Warn, bufferedMailTarget);
    config.LoggingRules.Add(mailRule);
    NLogBuilder.ConfigureNLog(config);
}
public override void Configure(IFunctionsHostBuilder builder)
{
    builder.Services.AddLogging(b =>
    {
        b.AddNLog();
    });
}
