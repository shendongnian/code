    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                this.SetLastColumnWidth();
    
                this.theListView.Layout += delegate
                {
                    this.SetLastColumnWidth();
                };
            }
    
            private void SetLastColumnWidth()
            {
                // Force the last ListView column width to occupy all the
                // available space.
                this.theListView.Columns[ this.theListView.Columns.Count - 1 ].Width = -2;
            }
    
            private void listView1_DrawColumnHeader( object sender, DrawListViewColumnHeaderEventArgs e )
            {
                // Fill header background with solid yello color.
                e.Graphics.FillRectangle( Brushes.Yellow, e.Bounds );
                // Let ListView draw everything else.
                e.DrawText();
            }
        }
    }
