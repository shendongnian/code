    try
    {
        bool foundHeldDie = false;
        for (int i = 0; i < 6; ++i)
        {
            // your code, which sets foundHeldDie to true if appropriate
            if (holds[i].Checked == true)
            {
                foundHeldDie = true;
                holds[i].Enabled = false;
            }  
        }
        if (!foundHeldDie)
        {
            // throw the exception
        }
    }
    catch (Exception ex)
    {
        // handle the exception
    }
