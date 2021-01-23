     if (!isExpanded())
                {
                    Viewbox vb = new Viewbox();
    
                    ClassMetricView metricView = new ClassMetricView();
                    metricView.Width = 300;
                    metricView.Height = 300;
                    metricView.ClassName = this.name;
                    metricView.NumberOfMetrics = 5;
                    metricView.NumberOfRevisions = 6;
                    metricView.MetricsName = new string[] { "LOC", "FanIn", "FanOut", "NOM", "McCabe" };
                    int[,] values = { { 10, 10, 10, 10, 10 }, { 20, 20, 20, 20, 20 }, { 30, 30, 30, 30, 30 }, { 40, 40, 40, 40, 40 }, { 50, 50, 50, 50, 50 }, { 60, 60, 60, 60, 60 } };
                    metricView.Metrics = values;
                    metricView.buildComponent();
                    vb.Child = metricView;
                    vb.AddHandler(StackPanel.SizeChangedEvent, new System.Windows.SizeChangedEventHandler(SizeChangedHandler));
    
                    surfaceWindow.ClassScatter.Items.Add(vb);
    
                    ScatterViewItem svItem = _surfaceWindow.ClassScatter.ItemContainerGenerator.ContainerFromItem(vb) as ScatterViewItem;
                    svItem.Tag = this.name;
                    svItem.AddHandler(ScatterViewItem.ScatterManipulationDeltaEvent, new ScatterManipulationDeltaEventHandler(MovementHandler));
                    svItem.AddHandler(StackPanel.SizeChangedEvent, new System.Windows.SizeChangedEventHandler(ScatterSizeChanged));
                    
                    this.setExpanded(true);
                }
