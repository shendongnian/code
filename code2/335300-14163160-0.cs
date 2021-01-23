    public static class Extensions
    {
        public static void AddUniqueAttributeOnNewLine(this CodeFunction2 func, string name, string value)
        {
            bool found = false;
            // Loop through the existing elements and if the attribute they sent us already exists, then we will not re-add it.
            foreach (CodeAttribute2 attr in func.Attributes)
            {
                if (attr.Name == name)
                {
                    found = true;
                }
            }
            if (!found)
            {
                // Get the starting location for the method, so we know where to insert the attributes
                var pt = func.GetStartPoint();
                EditPoint p = (func.DTE.ActiveDocument.Object("") as TextDocument).CreateEditPoint(pt);
                // Insert the attribute at the top of the function
                p.Insert(string.Format("[{0}({1})]\r\n", name, value));
                // Reformat the document, so the new attribute is properly aligned with the function, otherwise it will be at the beginning of the line.
                func.DTE.ExecuteCommand("Edit.FormatDocument");
            }
        }
    }
