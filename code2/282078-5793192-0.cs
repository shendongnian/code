    var from = Convert.ToInt32(box1.Text);
    var to = Convert.ToInt32(box2.Text);
    for(int i = from; i <= to; i++)
    {
        if (i % 2 == 0)
        {
            SomehowOutput(i);
        }
    }
