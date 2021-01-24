    private void allRootsWithChilds_CheckedChanged(object sender, EventArgs e)
    {
        var winWordMain = new NativeWindow();
        var parent = Globals.ThisAddIn.Application.ActiveWindow;
        winWordMain.AssignHandle(new IntPtr(parent.Hwnd));
        using (var objFormFoo = new ClsFormFoo())
        {
            // Set the Left and Top properties so this form is centered over the parent
            objFormFoo.Left = parent.Left + (parent.Width - objFormFoo.Width) / 2;
            objFormFoo.Top = parent.Top + (parent.Height - objFormFoo.Height) / 2;
            objFormFoo.ShowDialog(winWordMain);
        }
        winWordMain.ReleaseHandle();
    }
