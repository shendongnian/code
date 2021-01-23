    internal class MyControlDesigner : ControlDesigner {
        private DesignerActionListCollection actionLists;
        public override DesignerActionListCollection ActionLists {
            get {
                if (actionLists == null) {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new MyActionListItem(this));
                }
                return actionLists;
            }
        }
    }
