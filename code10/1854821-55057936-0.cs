    private void RunAll(var[] parm)
    {
        foreach(var p in parm[0])
        {
            //Do something.
            if(parm.Count()>1) RunAll(parm.Skip(1).ToArray());
            else
            {
                //Do something for the bottom-most param.
            }
        }
    }
            
