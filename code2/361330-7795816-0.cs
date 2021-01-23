     void Replace(TreeNode node,string text)
          {
             node.Text = text;
             for (int i = 0; i < node.Nodes.Count; i++)
              {
                 Replace(node.Nodes[i],text);
              }
          }
