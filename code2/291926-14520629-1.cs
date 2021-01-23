    // Redirect the mouse wheel event from panel1 to panel2.
    // When the panel1 is focused and the mouse wheel is used the panel2 will scroll.
    private void panel1_MouseWheel(object sender, MouseEventArgs e)
    {
       // Get the MouseWheel event handler on panel2
       System.Reflection.MethodInfo onMouseWheel = 
           panel2.GetType().GetMethod("OnMouseWheel", 
                                       System.Reflection.BindingFlags.NonPublic | 
                                       System.Reflection.BindingFlags.Instance);
       // Call the panel2 mousehwweel event with the same parameters
       onMouseWheel.Invoke(panel2, new object[] { e });
    }
