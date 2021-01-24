    [LayoutRenderer("nunit-testname")]
    public class NUnitTestNameLayoutRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(NUnit.Framework.CurrentContext?.Test?.Name);
        }
    }
