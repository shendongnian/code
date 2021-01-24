        public void BuildModel()
        {
            this.model = new PlotModel();
            this.lineserie = new LineSeries();
            this.lineserie.Points.Add(new DataPoint(0, 0));
            this.lineserie.Points.Add(new DataPoint(1, 70));
            this.lineserie.Points.Add(new DataPoint(2, 20));
            this.lineserie.Points.Add(new DataPoint(3, 20));
            this.model.Series.Add(lineserie);
            this.DataContext = this;
        }
