    private void Compare()
        {
            String[] ProjectOneFiles = ProjOneFiles();
            String[] ProjectTwoFiles = ProjTwoFiles();
            String[] ProjectOneHash = ProjOneHash();
            String[] ProjectTwoHash = ProjTwoHash();
            for (int x = 0; x < ProjectOneFiles.length || x < ProjectTwoFiles.length; ++x)
            {
                String Test1 = x < ProjectOneFiles.length ? ProjectOneFiles[x] : "";
                String Test2 = x < ProjectTwoFiles.length ? ProjectTwoFiles[x] : "";
                String Test3 = x < ProjectOneFiles.length ? ProjectOneHash[x] : "";
                String Test4 = x < ProjectTwoFiles.length ? ProjectTwoHash[x] : "";
                if (Test1.CompareTo(Test2) != 0)
                {
                    listBox6.Items.Add(Test1);
                    listBox6.Items.Add(Test2);
                }
                else if (Test3.CompareTo(Test4) == 0)
                {
                    listBox7.Items.Add(Test1);
                }
                else
                {
                    listBox8.Items.Add(Test1);
                }
            }
        }
