    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public partial class frmTLPTest1 : Form
    {
        public frmTLPTest1()
        {
            InitializeComponent();
            this.tlp1.RowStyles.RemoveAt(1);
        }
        private void SOfrmTest1_Load(object sender, EventArgs e)
        {
            TlpAddRow(this.tlp1, false);
        }
        Random rnd = new Random();
        Size[] sizes = new Size[] { new Size(75, 75), new Size(100, 100), new Size(125, 125)};
        Color[] colors = new Color[] { Color.Red, Color.LightGreen, Color.YellowGreen, Color.SteelBlue };
        Control selectedObject = null;
        Control selectedParent = null;
        private void btnAddControl_Click(object sender, EventArgs e)
        {
            Size size = new Size(125, 125);
            if (this.chkRandom.Checked)
                size = sizes[rnd.Next(sizes.Length)];
            
            PictureBox pBox = new PictureBox()
            {
                Anchor = AnchorStyles.None,
                BackColor = colors[rnd.Next(colors.Length)],
                MinimumSize = size,
                Size = size
            };
            bool drawborder = false;
            pBox.MouseEnter += (s, evt) => { drawborder = true;  pBox.Invalidate(); };
            pBox.MouseLeave += (s, evt) => { drawborder = false; pBox.Invalidate(); };
            pBox.MouseDown += (s, evt) => { selectedParent = pBox.Parent;
                                            selectedObject = pBox;  pBox.Invalidate();
            };
            pBox.Paint += (s, evt) => {
                if (drawborder) {
                    ControlPaint.DrawBorder(evt.Graphics, pBox.ClientRectangle, 
                                            Color.White, ButtonBorderStyle.Solid);
                }
            };
            if (this.tlp1.RowCount == 0) TlpAddRow(this.tlp1, true); 
            var ctl = this.tlp1.GetControlFromPosition(0, this.tlp1.RowCount - 1);
            int overallWith = 0;
            if (ctl.Controls?.Count > 0)
                overallWith = ctl.Controls.OfType<Control>().Sum(c => c.Width + c.Margin.Left + c.Margin.Right);
            overallWith += ctl.Margin.Right + ctl.Margin.Left + pBox.Size.Width + pBox.Margin.Left + pBox.Margin.Right;
            if (overallWith >= this.tlp1.Width) {
                ctl = TlpAddRow(this.tlp1, true);
            }
            ctl.Controls.Add(pBox);
        }
        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (selectedParent is null) return;
            if (selectedParent.Controls.Count > 0)
            {
                for (int i = 0; i == selectedParent.Controls.Count - 1; i++) {
                    selectedParent.Controls[i].Dispose();
                }
            }
            TLPRemoveRow(this.tlp1, selectedParent);
            selectedParent.Dispose();
        }
        private void btnRemoveControl_Click(object sender, EventArgs e)
        {
            if (selectedObject is null) return;
            Control parent = selectedObject.Parent;
            selectedObject.Dispose();
            if (parent?.Controls.Count == 0) {
                TLPRemoveRow(this.tlp1, parent);
                parent.Dispose();
            }
        }
        private Control TlpAddRow(TableLayoutPanel tlp, bool addRowCount)
        {
            var flp = new FlowLayoutPanel() {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };
            tlp.SuspendLayout();
            if (addRowCount) tlp.RowCount += 1;
            tlp.Controls.Add(flp, 0, tlp.RowCount - 1);
            tlp.ResumeLayout(true);
            return flp;
        }
        private void TLPRemoveRow(TableLayoutPanel tlp, Control control)
        {
            int ctlRow = this.tlp1.GetRow(control);
            TLPRemoveRow(tlp, ctlRow);
        }
        private void TLPRemoveRow(TableLayoutPanel tlp, int row)
        {
            if (row < this.tlp1.RowCount - 1) {
                for (int i = row; i < this.tlp1.RowCount - 1; i++) {
                    tlp.SetRow(tlp.GetControlFromPosition(0, i + 1), i);
                }
            }
            tlp.RowCount -= 1;
        }
    }
