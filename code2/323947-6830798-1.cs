    for(int i = 0; i < ProjectOneFiles.Length; i++)
    {
        //Add to the dictionary using hashDic.Add(FILENAME_HERE, HASH_HERE).
    }
    
    for(int i = 0; i < ProjectTwoFiles.Length; i++)
    {
        string projectOneValue;
        if(hashDic.TryGetValue(ProjectTwoFiles[i], out projectOneValue))
        {
            //If this code executes, you'll know that the file is in both projects.
            //The hash for the file in project one is in "projectOneValue."
            //The hash for the file in project two is in "ProjectTwoHash[i]".
            
            //You can remove this entry from the dictionary using
            //hashDic.Remove(FILE_NAME_HERE)
        }
        else
        {
            //If this code executes, then this file is only in ProjectTwo.
        }
    }
    //This loop will loop over all the files that are ONLY in ProjectOne.
    foreach(KeyValuePair<string, string> kvp in hashDic)
    {
        //kvp.Key is the filename.
        //kvp.Value is the hash.
        //For every pass of this loop you'll be looking at a different
        //file/hash that is ONLY in project one.
    }
