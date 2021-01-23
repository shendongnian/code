    private static void AdjustIndex(HashSet<int> index, int oldPos, int byHowMuch)
    {
        var oldIndex = new List<int>(index);
        index.Clear();
        foreach (var pos in oldIndex)
        {
            if (pos < oldPos)
                index.Add(pos);
            else
                index.Add(pos + byHowMuch);
        }           
    }
    private static bool ReplaceCid(HashSet<int> index, ref string html, string cid, string path)
    {
        var posToRemove = -1;
        foreach (var pos in index)
        {
            if (pos + cid.Length < html.Length && html.Substring(pos, cid.Length) == cid)
            {
                var sb = new StringBuilder();
                sb.Append(html.Substring(0, pos-CidPattern.Length));
                sb.Append(path);
                sb.Append(html.Substring(pos + cid.Length));
                html = sb.ToString();
                posToRemove = pos;
                break;
            }
        }
        
        if (posToRemove < 0)
            return false;
        
        index.Remove(posToRemove);
        AdjustIndex(index, posToRemove, path.Length - (CidPattern.Length + cid.Length));
        
        return true;
    }
