    viewGrid.Dock = Dock.Fill;
    viewGrid.Visible = true; // show grid initially
    viewGrid.Parent = pnlContainer;
    viewChart.Dock = Dock.Fill;
    viewChart.Visible = false; // hide chart initially
    viewChart.Parent = pnlContainer;
    // ...
    void btn_ToggleView(object sender, EventArgs e){
        bool showChart = viewGrid.Visible;
        viewGrid.Visible = !showChart;
        viewChart.Visible = showChart;
    }
