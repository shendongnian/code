    public class ElementCollection : KeyedCollection<CustomId, Element>
    {
        public override CustomId GetKeyForItem(Element element)
        {
            return element.id;
        }
    }
