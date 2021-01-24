    public partial class ParentInterface : Form
    {
        ...
        public void AddDynamicPanelControl( Control control ) {
          this.dynamicPanel.Controls.Add( control );
        }
        public void RemoveDynamicPanelControl( Control control ) {
          this.dynamicPanel.Controls.Remove( control );
        }
    }
