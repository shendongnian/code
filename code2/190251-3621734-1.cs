     static bool IsFileUsedbyAnotherProcess(string filename) 
            { 
                try 
                { 
                    using(var file = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                    }
                } 
                catch (System.IO.IOException exp) 
                { 
                    return true; 
                } 
                return false; 
            }
