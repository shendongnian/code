    static public void ToggleDesktop(object sender, EventArgs e)
            {
                var shellObject = new Shell32.Shell();
                shellObject.ToggleDesktop();
            }
