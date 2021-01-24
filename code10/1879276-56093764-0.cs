     public async Task<JsonResult> DonutChartData()
            {
                int tagIn = (await db.Tag.Where(x => x.IsIn == true).ToListAsync()).Count;
                int cardIn = (await db.Entry.Where(c => c.Type == Type.Card).Where(x => x.IsExit == false).ToListAsync()).Count;
                int reservedIn = (await db.Cars.Where(c => c.Type == Type.Pin).Where(x => x.IsExit == false).ToListAsync()).Count;
                DonutChart _chart = new DonutChart();
                _chart.labels = new string[] { "x", "y", "x" };
                _chart.datasets = new List<DonutChartDatasets>();
                List<DonutChartDatasets> _dataSet = new List<DonutChartDatasets>();
                _dataSet.Add(new DonutChartDatasets()
                {
                    label = "Whois",
                    //TO-DO: Add Reserve to Report
                    data = new int[] { cardIn, tagIn, reservedIn },
                    backgroundColor = new string[] { "rgba(54, 162, 235,0.5)", "rgba(255, 205, 86,0.5)", "rgba(255,99,132,0.5)" },
                    borderColor = new string[] { "rgb(54, 162, 235)", "rgb(255, 205, 86)", "rgb(255,99,132)" },
                    borderWidth = "1"
                });
                _chart.datasets = _dataSet;
                return Json(_chart, JsonRequestBehavior.AllowGet);
            }
