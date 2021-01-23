    public override PolicyFailure[] Evaluate()
    {
        List<PolicyFailure> failures = new List<PolicyFailure>();
        foreach(PendingChange pc in PendingCheckin.PendingChanges.CheckedPendingChanges)
        {
            if(pc.LocalItem == null)
            {
                continue;
            }
            /* Open the file */
            using(FileStream fs = new FileStream(pc.LocalItem, ...))
            {
                if(/* File contains your prohibited code */)
                {
                    failures.Add(new PolicyFailure(/* Explain the problem */));
                }
                fs.Close();
            }
        }
        return failures.ToArray();
    }
