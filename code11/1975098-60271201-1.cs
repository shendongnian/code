protected override string Transform(LogEventInfo logEvent, string text)
{
    // Render...
    var replacementString = Replacement.Render(logEvent);
    // Now just put in the rendered replacement string.
    return text.Replace(Environment.NewLine, replacementString);
}
Full code (after some cleaning):
C#
using System;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.LayoutRenderers.Wrappers;
using NLog.Layouts;
namespace My.Namespace
{
    [LayoutRenderer("replace-newlines-withlayout")]
    [ThreadAgnostic]
    public class ReplaceNewLinesFormatLayoutRendererWrapper : WrapperLayoutRendererBase
    {
        public Layout Replacement { get; set; } = " ";
        protected override string Transform(LogEventInfo logEvent, string text)
        {
            // Render...
            var replacementString = Replacement.Render(logEvent);
            // Now just put in the rendered replacement string.
            return text.Replace(Environment.NewLine, replacementString);
        }
    }
}
