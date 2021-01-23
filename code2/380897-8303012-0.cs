    public void characterGeneration(string classSelected, Type stat)
    {
        foreach (string classInList in classes.ClassList)
        {
            if (classSelected == classInList)
            {
                PlayerOneStats = (MageBase)Activator.CreateInstance(stat);
                break;
            }
        }
    
        PlayerOneStats.generateStats();
    }
