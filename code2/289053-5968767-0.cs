    using System;
    using System.Data;
    using System.Windows.Forms;
    
    namespace Demo {
        public class TestClass {
            DataTable table;
    
            public void Initialize() {
                table = new DataTable();
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("ParentID", typeof(int));
                table.Columns.Add("Text", typeof(String));
            }
    
            private void UpdateTreeData(TreeNode parentNode) {
                int parentId = Convert.ToInt32(parentNode.Tag);
                int childId;
                foreach (TreeNode n in parentNode.Nodes)
                {   // Assuming Tag contains the table ID value...
                    childId = Convert.ToInt32(n.Tag);
                    table.Select("ID = " + childId.ToString())[0]["ParentID"] = parentId;
                    UpdateTreeData(n);
                }
            }
        }
    }
    }
