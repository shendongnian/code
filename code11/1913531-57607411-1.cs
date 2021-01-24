    public ActionResult test()
        {
            IEnumerable<Line> line = new List<Line> 
                { new Line{
                     IdGroup = 100,
                     GroupName = "Nojan",
                     RowLane = new List<RowLane> { new RowLane { IdLane = "1", IsChecked = true, LaneName = "pizza"},
                                                   new RowLane { IdLane = "2", IsChecked = false, LaneName = "lazogna"}
                     }
                    },
                     new Line{
                     IdGroup = 101,
                     GroupName = "Noj",
                     RowLane = new List<RowLane> { new RowLane { IdLane = "3", IsChecked = false, LaneName = "pizza"},
                                                   new RowLane { IdLane = "4", IsChecked = false, LaneName = "lazogna"}
                     }
                }                     
        };
    
            return View(line.ToList());
        }
    
    
    public ActionResult ProcessLane(int? IdGroup, List<RowLane> input)
    {
            // Code here as you wish, form is submitted to this method
    }
