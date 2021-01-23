    public class DebugRadioElement : RadioElement {
        Action<DebugRadioElement, EventArgs> onCLick;
    
        public DebugRadioElement (string s, Action<DebugRadioElement, EventArgs> onCLick) : base (s) {
            this.onCLick = onCLick;
        }
    
        public override void Selected (DialogViewController dvc, UITableView tableView, NSIndexPath path)
        {
            base.Selected (dvc, tableView, path);
            var selected = onCLick;
            if (selected != null)
            selected (this, EventArgs.Empty);
        }
    }
