    namespace Test_MenuItemIteration
    {
        using System.Collections.Generic;
        using System.Windows.Forms;
     
        public static class GetAllMenuStripItems
        {
            #region Methods
     
            /// <summary>
            /// Gets a list of all ToolStripMenuItems
            /// </summary>
            /// <param name="menuStrip">The menu strip control</param>
            /// <returns>List of all ToolStripMenuItems</returns>
            public static List<ToolStripMenuItem> GetItems(MenuStrip menuStrip)
            {
                List<ToolStripMenuItem> myItems = new List<ToolStripMenuItem>();
                foreach (ToolStripMenuItem i in menuStrip.Items)
                {
                    GetMenuItems(i, myItems);
                }
                return myItems;
            }
     
            /// <summary>
            /// Gets the menu items.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="items">The items.</param>
            private static void GetMenuItems(ToolStripMenuItem item, List<ToolStripMenuItem> items)
            {
                items.Add(item);
                foreach (ToolStripItem i in item.DropDownItems)
                {
                    if (i is ToolStripMenuItem)
                    {
                        GetMenuItems((ToolStripMenuItem)i, items);
                    }
                }
            }
     
            #endregion Methods
        }
    }
