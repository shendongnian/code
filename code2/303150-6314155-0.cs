    private void pMouseMove(object sender, MouseEventArgs e)
    {
        // print out e.OriginalSource just for learning purposes
        Console.WriteLine("OriginalSource:" + e.OriginalSource.ToString());
        if (e.OriginalSource is Canvas)
        {
            // your logic here
        }
    }
