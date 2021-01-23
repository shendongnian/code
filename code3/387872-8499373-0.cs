    public class Element
    {
        public Element(string Name)
        {
            this.Name = Name;
        }
        public string Name { get; set; }
        public ElementCollection Children = new ElementCollection();
        // This method is used to add the specified child name if it does not currently 
        // exist, or return the existing one if it does
        public Element AddOrFetchChild(string sName)
        {
            Element oChild;
            if (this.Children.ContainsKey(sName))
            {
                oChild = this.Children[sName];
            }
            else
            {
                oChild = new Element(sName);
                this.Children.Add(sName, oChild);
            }
            return oChild;
        }        
    }
    public class ElementCollection : System.Collections.Generic.Dictionary<string, Element>
    {
    }
