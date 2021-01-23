    private bool MoveNext()
    {
        try
        {
            switch (this.<>1__state)
            {
                case 0:
                    this.<>1__state = -1;
                    RuntimeHelpers.PrepareConstrainedRegions();
                    this.<>1__state = 1;
                    Program.cerWorked = false;
                    this.<>2__current = 5;
                    this.<>1__state = 2;
                    return true;
    
                case 2:
                    this.<>1__state = 1;
                    this.<>m__Finally2();
                    break;
            }
            return false;
        }
        fault
        {
            this.System.IDisposable.Dispose();
        }
    }
