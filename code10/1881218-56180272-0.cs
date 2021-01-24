        if (CheckBXAccess.Checked)
        {
        extracost += 1;
        }
        
        if (CheckBXTrainer.Checked)
        {
        extracost += 20;
        }
        
        if (CheckBXDiet.Checked)
        {
        extracost += 20;
        }
        
        if (CheckBXVideo.Checked)
        {
        extracost = +20;
        }
        
        Extrachargetxtbx.Text = extracost.ToString();
        return;
 
