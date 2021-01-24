    public override void Post(SendOrPostCallback d, Object state) {
        Debug.Assert(controlToSendTo != null, "Should always have the marshaling control by this point");
 
        if (controlToSendTo != null) {
            controlToSendTo.BeginInvoke(d, new object[] { state });
        }
    }
