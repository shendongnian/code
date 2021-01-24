    public bool IsProcessOpen(string name)
        {
            Process[] p = Process.GetProcessesByName(name);  ///Get the process by a name
            if(p.Length == 0) /// if the length of the array is 0, then it means its not running.
            {
                return false;
            }
            else /// if its other then 0 it means its its running.
            {
                return true;
            }
        } 
