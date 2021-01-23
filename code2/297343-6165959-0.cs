    void SetVisibility(int index)
    {
        // do index validation 
        
        textboxes[index].Visible = true;
        for (int i = 0; i < textboxes.Length; i++)
        {
            if (i != index) textboxes[i].Visible = false;
        }
    }
