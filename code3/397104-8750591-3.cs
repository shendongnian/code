    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace Test
    {
        public class SortXmlFile
        {
            XElement rootNode;
    
            public SortXmlFile(FileInfo file)
            {
                if (file.Exists)
                    rootNode = XElement.Load(file.FullName);
                else
                    throw new FileNotFoundException(file.FullName);
            }
    
            public XElement SortFile()
            {
                SortElements(rootNode);
                return rootNode;
            }
    
            public void SortElements(XElement root)
            {
                bool sortWithNumeric = false;
                XElement[] children = root.Elements().ToArray();
                foreach (XElement child in children)
                {
                    string name;
                    int value;
                    // does any child need to be sorted by numeric?
                    if (!sortWithNumeric && Sortable(child, out name, out value))
                        sortWithNumeric = true;
                    child.Remove(); // we'll re-add it in the sort portion
                    // sorting child's children
                    SortElements(child);
                }
                // re-add children after sorting
    
                // sort by name portion, which is either the full name, 
                // or name that proceeds period that has a numeric value after the period.
                IOrderedEnumerable<XElement> childrenSortedByName = children
                        .OrderBy(child =>
                            {
                                string name;
                                int value;
                                Sortable(child, out name, out value);
                                return name;
                            });
                XElement[] sortedChildren;
                // if needed to sort numerically
                if (sortWithNumeric)
                {
                    sortedChildren = childrenSortedByName
                        .ThenBy(child =>
                            {
                                string name;
                                int value;
                                Sortable(child, out name, out value);
                                return value;
                            })
                            .ToArray();
                }
                else
                    sortedChildren = childrenSortedByName.ToArray();
    
                // re-add the sorted children
                foreach (XElement child in sortedChildren)
                    root.Add(child);
            }
    
            public bool Sortable(XElement node, out string name, out int value)
            {
                var dot = new char[] { '.' };
                name = node.Name.ToString();
                if (name.Contains("."))
                {
                    string[] parts = name.Split(dot);
                    if (Int32.TryParse(parts[1], out value))
                    {
                        name = parts[0];
                        return true;
                    }
                }
                value = -1;
                return false;
            }
        }
    }
