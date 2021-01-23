    //bubble sort
        public  void Sort_TV_ByTag(TreeNodeCollection treeNodeCollection)
        {
    
            int i, j;
            int n = treeNodeCollection.Count;
    
            for (i = 0; i < n; i++)
            {
                for (j = 1; j < (n - i); j++)
                {
                    int firstValue = int.Parse(treeNodeCollection[j - 1].Tag.ToString());
                    int secondValue = int.Parse(treeNodeCollection[j].Tag.ToString());
    
                    //you can compare by Tag , Text , anything 
                    if (firstValue > secondValue)
                    {
                        
                        //swap the nodes
                        TreeNode n1 = treeNodeCollection[j - 1];
                        TreeNode n2 = treeNodeCollection[j];
                        treeNodeCollection.Remove(n1);
                        treeNodeCollection.Remove(n2);
                        treeNodeCollection.Insert(j, n1);
                        treeNodeCollection.Insert(j - 1, n2);
    
                    }
                    
                }
            }
    
        }
    
            
        private void button1_Click(object sender, EventArgs e)
        {
            Sort_TV_ByTag(treeView1.Nodes[0].Nodes);
        }
