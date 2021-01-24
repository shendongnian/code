    public void RemoveAnnotation(IEnumerable<Annotation> annotations)
    {
        foreach (var annotation in annotations)
        {
            if (MyOxyPlotModel.Annotations.Contains(annotation))
                MyOxyPlotModel.Annotations.Remove(annotation);
            else if (annotation is TextualAnnotation ta)
            {
                var existingTa = MyOxyPlotModel.Annotations.OfType<TextualAnnotation>().FirstOrDefault(x => x.Text == ta.Text);
                if (existingTa != null)
                    MyOxyPlotModel.Annotations.Remove(existingTa);
            }
        }
        RefreshAxisSeriesPlot();
    }
