    Label[,] dashboardLabels = new Label[3,14];
    
    private void Form1_Shown(object sender, EventArgs e)
    {
      CreateLabels(); // create and position labels (no binding yet)
    }
    
    public void CreateLabels(int cols = 3, int rows = 14)
    {
      
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                // Create label...
                Label l = new Label();
                l.Text = "N/A";
                l.ForeColor = Color.Red
                dashboardLabels[col, row] = l;
                this.Controls.Add(l);
      
                // Position label over DGV cell...
                Point dgvCell = dataGridView1.GetCellDisplayRectangle(col + 2, rowNumbersLabel[row], false).Location;
                Point dgvGrid = dataGridView1.Location;
                l.Left = dgvGrid.X + dgvCell.X;
                l.Top = dgvGrid.Y + dgvCell.Y;
            }
        }
    }
    private void UpdateLabels(List<Dog> dogs)
    {
        for (int i = 0; i < dogs; i++)
        {
            if (!dashboardLabels[i, 0].Visible) dashboardLabels[i, 0].Visible = true;
            if (dogs[i].IsSetUp) BindLabel(dashboardLabels[i, 0], dogs[i],"Name");
        }
    }
    private void BindLabel(Label l, Dog dog, string observation)
        {
            Binding b = new Binding("Text", dog, observation);
            l.DataBindings.Add(b);
            l.ForeColor = Color.Green;
        }
    }
