    List<string> list1 = new List<string>();
    list1.Add(@"c:\abc\pqr\tmp\sample\b.txt");
    list1.Add(@"c:\abc\pqr\tmp\new2\c1.txt");
    list1.Add(@"c:\abc\pqr\tmp\b2.txt");
    list1.Add(@"c:\abc\pqr\tmp\b3.txt");
    list1.Add(@"c:\abc\pqr\tmp\tmp2\b2.txt");
    
    string baseDir = "";
    foreach (var item in list1)
    {
        if (baseDir == "")
            baseDir = System.IO.Path.GetDirectoryName(item);
        else
        {
            int index = 0;
            string nextDir = System.IO.Path.GetDirectoryName(item);
            while (index< baseDir.Length && index<nextDir.Length && 
                baseDir[index] == nextDir[index])
            {
                index++;
            }
            baseDir = baseDir.Substring(0, index);
        }
    }
    MessageBox.Show(baseDir);
