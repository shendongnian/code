    private void test(TextBox textBox1, TextBox textBox2)
        {
            string[] text1Val = textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] text2Val = textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int count = 1;
            XDocument srcTree = new XDocument(new XElement("element"));
            for(int i=0;i<text1Val.Count();i++)
            {
                for(int j=i;j<=i;j--)
                {
                    srcTree.Add(new XElement("Entry"+count,text1Val[i]));
                    srcTree.AddAfterSelf(new XElement("Entry"+count+1,text2Val[j]));
                }
                count++;
            }
        }
