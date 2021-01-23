    private void BindLineToScatterViewItems(Line line, ScatterViewItem origin,
        ScatterViewItem destination)
    {
        // Bind line.(X1,Y1) to origin.ActualCenter  
        BindingOperations.SetBinding(line, Line.X1Property, new Binding {
            Source = origin, Path = new PropertyPath("ActualCenter.X") });  
        BindingOperations.SetBinding(line, Line.Y1Property, new Binding {
            Source = origin, Path = new PropertyPath("ActualCenter.Y") });
        
        // Bind line.(X2,Y2) to destination.ActualCenter  
        BindingOperations.SetBinding(line, Line.X2Property, new Binding {
            Source = destination, Path = new PropertyPath("ActualCenter.X") });  
        BindingOperations.SetBinding(line, Line.Y2Property, new Binding {
            Source = destination, Path = new PropertyPath("ActualCenter.Y") });
    }
