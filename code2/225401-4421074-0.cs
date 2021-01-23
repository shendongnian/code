    if (e.KeyChar.Equals('d') || e.KeyChar.Equals('j'))
    {
        //red hit
        if (!tmrRedHit.Enabled)
            tmrRedHit.Enabled = true;
    }
    else if (e.KeyChar.Equals('s') || e.KeyChar.Equals('k'))
    {
        //blue hit
        if (!tmrBlueHit.Enabled)
            tmrBlueHit.Enabled = true;
    }
