    public void UserInkControl_Click(object sender, EventArgs ea)
    {
       UserInkControl.Refresh ();  // Causes repainting immediately
       // or
       UserInkControl.Invalidate ();  // Invalidates the whole painting surface, 
       //so when the message loop catches up, it gets repainted.
       // There is also an overload of Invalidate that
       // lets you invalidate a particular part of the button,
       // So only this area is redrawn.  This can reduce flicker.
    }
