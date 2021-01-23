        #region SetupChart()
        public bool SetupChart()
        {
            try
            {
                //Here is where I create the chart scale to show 170 data points
                this.view.chart.ChartAreas[0].AxisX.ScaleView.Size = 170;
                return true;
            }
            catch { return false; }
        }
        #endregion
        #region Draw()
        public bool Draw()
        {
            try
            {
                view.Data = this.dllCall.GetData(1);
                int startSecond = 0;
                foreach (Int16 item in view.Data)
                {
                    this.view.chart.Series["MySeries"].Points.AddXY(startSecond, item);
                    startSecond++;
                }
                return true;
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return false;
            }
        }
        private void chart_AxisScrollBarClicked(object sender, System.Windows.Forms.DataVisualization.Charting.ScrollBarEventArgs e)
        {
            if (e.Axis == chart.ChartAreas[0].AxisX)
            {
                if (e.ButtonType == System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonType.SmallIncrement)
                    chart.ChartAreas[0].AxisX.ScaleView.Position += 170;
                else if (e.ButtonType == System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonType.SmallDecrement)
                    chart.ChartAreas[0].AxisX.ScaleView.Position -= 170;
            }
        }
