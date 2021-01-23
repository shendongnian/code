    internal class MyActionListItem : DesignerActionList {
        public MyActionListItem(ControlDesigner owner)
            : base(owner.Component) {
        }
        public override DesignerActionItemCollection GetSortedActionItems() {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("Hello world", "Category1"));
            items.Add(new DesignerActionPropertyItem("Checked", "Sample checked item"));
            return items;
        }
        public bool Checked {
            get { return ((MyControl)base.Component).Prop; }
            set { ((MyControl)base.Component).Prop = value; }
        }
    }
