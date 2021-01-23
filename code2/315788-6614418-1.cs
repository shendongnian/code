    public void CheckTimes
    {
        MFXProgramme previousProg = null;
        MFXProgramme nextProg = null;
        foreach (MFXProgramme prog in Programmes.OrderBy(p => p.Start))
        {
            nextProg = prog;
            if (previous != null)
            {
                if (previous.Stop != next.Start)
                {
                    //Gap
                }
            }
            previousProg = prog;
        }
    }    
    class MXFProgramme
    {
        ...
        public DateTime Start
        {
            get
            {
                return DateTime.Parse(xProgramme.Attributes["start"].Value);
            }
        }
        public DateTime Stop
        {
            get
            {
                return DateTime.Parse(xProgramme.Attributes["stop"].Value);
            }
        }
    }
