        static string GetUniqueName(Control c)
        {
            StringBuilder UniqueName = new StringBuilder();
            UniqueName.Append(c.Name);
            Form OwnerForm = c.FindForm();
            //Start with the controls immediate parent;
            Control Parent = c.Parent;
            while (Parent != null)
            {
                if (Parent != OwnerForm)
                {
                    //Insert the parent control name to the beginning of the unique name
                    UniqueName.Insert(0, Parent.Name + "."); 
                }
                else
                {
                    //Insert the form name along with it's namespace to the beginning of the unique name
                    UniqueName.Insert(0, OwnerForm.GetType() + "."); 
                }
                //Advance to the next parent level.
                Parent = Parent.Parent;
            }
            return UniqueName.ToString();
        }
