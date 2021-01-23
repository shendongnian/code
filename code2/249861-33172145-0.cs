        IEnumerable<string> GetFiles(string folder, string filter, bool recursive)
        {
            string [] found = null;
            try
            {
                found =  Directory.GetFiles(folder, filter);
            }
            catch { }
            if (found!=null)
                foreach (var x in found)
                    yield return x;
            if (recursive)
            {
                found = null;
                try
                {
                    found = Directory.GetDirectories(folder);
                }
                catch { }
                if (found != null)
                    foreach (var x in found)
                        foreach (var y in GetFiles(x, filter, recursive))
                            yield return y;
            }
        }
