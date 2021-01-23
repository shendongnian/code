    public static bool IsSubDirectoryOf(this string source, string candidate)
    {
        var isChild = false;
        try
        {
            var sourceInfo = new DirectoryInfo(source);
            var candidateInfo = new DirectoryInfo(candidate);
            while (candidateInfo.Parent != null)
            {
                if (candidateInfo.Parent.FullName == sourceInfo.FullName)
                {
                    isChild = true;
                    break;
                }
                else candidateInfo = candidateInfo.Parent;
            }
        }
        catch (Exception error)
        {
            var message = String.Format("Unable to check directories {0} and {1}: {2}", source, candidate, error);
            Trace.WriteLine(message);
        }
        return isChild;
    }
