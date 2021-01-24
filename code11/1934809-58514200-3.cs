    private static void RecursivelyRecordBounds(Control c)
    {
        c.Tag = c.Bounds;
        foreach (Control cc in c.Controls)
        {
            cc.Tag = cc.Bounds;
            if (cc.Controls.Count > 0)
            {
                RecursivelyRecordBounds(cc);
            }
        }
    }
