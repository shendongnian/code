    private void AddStriplines() {
            lineIntervalOffsets = new double[5] {1, 3, 6, 8, 10 };
            for (int i = 0; i < 5; i++) {
                StripLine line = StriplineConfig();
                Area.AxisY.StripLines.Add(line);
            }
        }
        private StripLine StriplineConfig() {
            StripLine line = new StripLine();
            line.BorderColor = Color.DarkGray;
            line.Interval = 12;
            return line;
        }
