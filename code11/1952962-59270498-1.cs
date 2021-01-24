    private void deletebutton_Click(object sender, EventArgs e)
    {
        // if you have created at least 1 button
        if (MyButtons.Count() > 0)
        {
            Button ButtonToRemove = MyButtons.Last(); // get the last added button
            Controls.Remove(ButtonToRemove); // remove it from the controls
            MyButtons.Remove(ButtonToRemove); // remove it from the list too
        }
    }
