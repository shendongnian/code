      public Form1()
      {
         InitializeComponent();
         grdCons.Rows.Add(7);
         for (int i = 0; i < grdCons.Rows.Count; i++)
         {
            grdCons.Rows[i].Cells[0].Value = i;
            grdCons.Rows[i].Cells[1].Value = "Cell " + i;
         }
         grdCons.AllowDrop = true;
         grdCons.AllowUserToAddRows = false;
         grdCons.AllowUserToDeleteRows = false;
         grdCons.MouseMove += new MouseEventHandler(grdCons_MouseMove);
         grdCons.MouseDown += new MouseEventHandler(grdCons_MouseDown);
         grdCons.DragOver += new DragEventHandler(grdCons_DragOver);
         grdCons.DragDrop += new DragEventHandler(grdCons_DragDrop);
      }
      private int rowIndexFromMouseDown;
      private void grdCons_MouseMove(object sender, MouseEventArgs e)
      {
         if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
         {
            grdCons.DoDragDrop(grdCons.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
         }
      }
      private void grdCons_MouseDown(object sender, MouseEventArgs e)
      {
         rowIndexFromMouseDown = grdCons.HitTest(e.X, e.Y).RowIndex;
      }
      private void grdCons_DragOver(object sender, DragEventArgs e)
      {
         e.Effect = DragDropEffects.Move;
      }
      private void grdCons_DragDrop(object sender, DragEventArgs e)
      {
         Point clientPoint = grdCons.PointToClient(new Point(e.X, e.Y));
         int targetIndex = grdCons.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
         if (e.Effect == DragDropEffects.Move)
         {
            DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
            grdCons.Rows.RemoveAt(rowIndexFromMouseDown);
            grdCons.Rows.Insert(targetIndex, rowToMove);
         }
      }
