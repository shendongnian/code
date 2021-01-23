    public void DoStuff()
    {
        List<IProcess> processorsForService1 = ProcessFactory.GetProcessors();
        foreach (IProcess p in processorsForService1)
        {
            if (p.ProcessTimer != null)
            {
                p.ProcessTimer.Elapsed += (s, e) =>
                {
                    p.Step_One();
                    p.Step_Two();
                };
            }
        }
    }
