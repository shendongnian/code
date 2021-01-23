private void RedrawStuff()
{
    // un-wire the change events
    chkState.CheckedChanged -= new System.EventHandler(chkState_CheckedChanged();
    numStateValue.ValueChanged -= new System.EventHandler(chkState_CheckedChanged();
    /*
      .... do you thing...including setting the state of both / either controls
           based on the state of things, without fear of triggering recursive changes...
    */
    // wire them back up
    chkState.CheckedChanged += new System.EventHandler(chkState_CheckedChanged();
    numStateValue.ValueChanged += new System.EventHandler(chkState_CheckedChanged();
}
(I've used this approach a few times as it seems to achieve the a solution to the problem you've described, but I would be happy if someone was to point out why, for reasons I may not understand, that it may be a bad approach.) 
