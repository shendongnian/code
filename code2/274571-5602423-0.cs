    const int Offset = 8; // for example
    int totalWidth = panel1.Controls.Cast<Control>().Aggregate(0, (value, ctrl) => value + ctrl.Width + Offset);
    for (int index = 0; index < panel1.Controls.Count; index++)
    {
        Control current = panel1.Controls[index];
        
        if (index == 0)
        {
            current.Left = startX;
        }
        else
        {
            current.Left = panel1.Controls[index-1].Right + Offset;
        }
    }
