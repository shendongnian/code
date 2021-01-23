    for(int i = 0; i < ProjectOneFiles.Length; i++)
    {
        //Add to the dictionary.
    }
    
    for(int i = 0; i < ProjectTwoFiles.Length; i++)
    {
        string projectOneValue;
        if(hashDic.TryGetValue(ProjectTwoFiles[i], out projectOneValue))
        {
            //This file was in both lists, you can compare their hashes and
            //act accordingly.
            //You can even remove the entry for project one files so that
            //at the end of the this loop, hashDic will only contain entries
            //for files that were in project one but not in project two.
        }
        else
        {
            //This file is only in ProjectTwo. You can act accordingly.
        }
    }
