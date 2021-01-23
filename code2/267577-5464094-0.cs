     public List<TreeNode> TreeTest()
        {
            var results1 = (from c in _Context.v_EntityTrees
                        where c.OU_TYPE_CD == "Type1"
                        orderby c.text
                        select c).ToList();
    
            var results2 = (from d in _Context.v_EntityTrees
                       where d.OU_TYPE_CD == "Type2"
                       orderby d.text
                       select d).ToList();
    
            TreeNode node = new TreeNode();
            List<TreeNode> nodelist = new List<TreeNode>();
            nodelist.Add(new TreeNode { text = "Parent1", cls = "folder", leaf = false, id = 1000, children = results1 });
            nodelist.Add(new TreeNode { text = "Parent2", cls = "folder", leaf = false, id = 2000, children = results2 });
    
            return nodelist;
        }
