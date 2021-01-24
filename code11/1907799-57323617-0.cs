    public class ProductStructure : LightProductStructure
    {
        private List<AbstractStructureNode> subNodes;
        public override List<AbstractStructureNode> SubNodes
        {
            get
            {
                // Lazy loading logic including API calls to set subNodes
                return subNodes;
            }
            set
            {
                subNodes = value;
            }
        }
     }
