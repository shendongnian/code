    // Set the picturebox loading state, resize the form etc.
    PictureBox.SetLoadingImage();
    // Initialize a new thread
    Thread t = new Thread(new ThreadStart(() =>
    {
        // Fill the gridview here
        GridView1.DataSource = FillWithData();
        GridView1.DataBind();
        // When finished, reset the picturebox on it's own thread
        PictureBox.Invoke((MethodInvoker)(()=> PictureBox.ClearLoadingImage() ));
    }));
 
    // Run the thread.
    t.Start();
