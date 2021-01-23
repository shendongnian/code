    private void Compare()
    {
        String[] ProjectOneFiles = ProjOneFiles();
        String[] ProjectTwoFiles = ProjTwoFiles();
        String[] ProjectOneHash = ProjOneHash();
        String[] ProjectTwoHash = ProjTwoHash();
        //make project one the greater of the two always
        if (ProjectTwoFiles.Length > ProjectTwoFiles.Length)
        {
            Swap(ref ProjectOneFiles, ref ProjectTwoFiles);
            Swap(ref ProjectOneHash, ref ProjectTwoHash);
        }
        for (int x = 0; x < ProjectTwoFiles.length; x++)
        {
            String Test1 = ProjectOneFiles[x];
            String Test2 = ProjectTwoFiles[x];
            String Test3 = ProjectOneHash[x];
            String Test4 = ProjectTwoHash[x];
            if (Test1 != Test2)
            {
                listBox6.Items.Add(Test1);
                listBox6.Items.Add(Test2);
            }
            else if ((Test1 == Test2) && (Test3 == Test4))
            {
                listBox7.Items.Add(Test1);
            }
            else
            {
                listBox8.Items.Add(Test1);
            }
        }
        for (int x = ProjectTwoFiles.Length + 1; x < ProjectOneFiles.length; x++)
        {
            //add to some other list
        }
    }
    private static void Swap(ref string[] foo, ref string[] bar)
    {
        string[] tmp = foo;
        foo = bar;
        bar = tmp;
    }
