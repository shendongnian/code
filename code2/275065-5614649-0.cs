    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            treeView1.AllowDrop = true;
            treeView1.DragEnter += treeView1_DragEnter;
            treeView1.DragOver += treeView1_DragOver;
        }
        protected override void OnMouseDown(MouseEventArgs e) {
            DoDragDrop("foo", DragDropEffects.Copy);
            base.OnMouseDown(e);
        }
        private void treeView1_DragEnter(object sender, DragEventArgs e) {
            // TODO: check e.Data
            e.Effect = DragDropEffects.Copy;
        }
        private void treeView1_DragOver(object sender, DragEventArgs e) {
            Point pos = treeView1.PointToClient(new Point(e.X, e.Y));
            var hit = treeView1.HitTest(pos);
            TreeNode node = hit.Node;
            if (hit.Node != null) {
                node.Expand();
                if (node.Level != 1) node = null;
            }
            e.Effect = node != null ? DragDropEffects.Copy : DragDropEffects.None;
        }
    }
