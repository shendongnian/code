        private void chart1_Customize(object sender, EventArgs e)
        {
            foreach (var label in chart1.ChartAreas[0].AxisY.CustomLabels)
            {
                label.Text = (double.Parse(label.Text) - 150).ToString();
            }
        }
