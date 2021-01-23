    void panel1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
    {
        if (Keyboard.IsKeyDown(Key.Space))
        {
            if (label1.Text == "foo") label1.Text = "bar"; else label1.Text = "foo";
        }
    }
