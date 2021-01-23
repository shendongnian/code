        public static void FindControlsRecursive(Control root, Type type, ref List<Control> list)
        {
            if(root.Controls.Count != 0)
            {
                foreach(Control c in root.Controls)
                {
                    if(c.GetType() == type)
                        list.Add(c);
                    else if (c.HasControls())
                        FindControlsRecursive(c, type, ref list);
                }
            }
        }
