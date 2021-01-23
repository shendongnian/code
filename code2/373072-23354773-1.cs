    public static bool IsSubDirectoryOf(this string candidate, string other)
    {
        var isChild = false;
        try
        {
            var candidateInfo = new DirectoryInfo(candidate);
            var otherInfo = new DirectoryInfo(other);
    
            while (candidateInfo.Parent != null)
            {
                if (candidateInfo.Parent.FullName == otherInfo.FullName)
                {
                    isChild = true;
                    break;
                }
                else candidateInfo = candidateInfo.Parent;
            }
        }
        catch (Exception error)
        {
            var message = String.Format("Unable to check directories {0} and {1}: {2}", candidate, other, error);
            Trace.WriteLine(message);
        }
    
        return isChild;
    }
