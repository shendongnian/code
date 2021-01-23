    foreach (string line in simpleList)
    {
        string rec_idGB = line.Split('\t')[0].Substring(4).Trim();
        string tagGB = line.Split('\t')[2].Substring(7).Trim();
        bool thereIsAMatch = false;
        foreach (string line2 in fullList)
        {
            if (line2.Contains(rec_idGB) && line2.Contains(tagGB))
            {
                thereIsAMatch = true;
                break;
            }
        }
        if(!thereIsAMatch)
        {
            // This is what you want?
        }
    }
