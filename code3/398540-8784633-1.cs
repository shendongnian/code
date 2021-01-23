    foreach (string line in lines)
    {
        // Modify the inner foreach to do the split on ' ' here
        // instead of split_text
        foreach (string av in line.Split(' '))
        {
            if (av == "")
            {
                space_count++;
            }
            else
            {
                new_text = new_text + av + ",";
            }
        }
    }
    new_text = new_text.TrimEnd(',');
    // use lines here instead of split_text
    lines = new_text.Split(',');
    MessageBox.Show(lines.Length.ToString());
    }
        
