    for (int i = 0; i < ckbObjectives.Items.Count; i++)
    {
        MessageBox.Show(String.Format("{0}: {1}", 
                        ckbObjectives.GetItemText(ckbObjectives.Items[i]),
                        ckbObjectives.GetItemCheckState(i).ToString())); 
    }
