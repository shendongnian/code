You can't "jump ahead" to the rendering because there aren't any conditionals in ProcessRequestMain to allow for it. The only option is to hack the event handlers of the relevant controls.
    protected void Page_Load(object sender, EventArgs e) {
        // DON'T DO THIS!! Years from now, some poor soul tasked with
        // debugging your code will tear their hair out, until they
        // discover the unholy magic you have conjured herein. Keep in mind
        // this is the 21st century and this person knows where you live.
        // 
        // Seriously, just use the validation built in to ASP.NET.
        if ("true".Equals(Request.QueryString["disable_events"], StringComparison.OrdinalIgnoreCase)) {
            // disable *all* event handlers on button controls
            foreach (var b in this.GetControlDescendants().OfType<Button>()) {
                var eventList = (EventHandlerList) typeof (Control)
                    .GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(b, null);
                typeof (EventHandlerList)
                    .GetField("head", BindingFlags.Instance | BindingFlags.NonPublic)
                    .SetValue(eventList, null);
            }
        }
    }
