    public void mProcessArgs(string[] args)
        {
            if (args.Length > 0)
            {
                for (int i = **1**; i < args.Length; i++)
                {
                    if (System.IO.File.Exists(args[i])) { this.OpenFile(args[i]); }
                }
            }
        }
