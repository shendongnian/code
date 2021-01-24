    var assistant = new BindingAssistant
    {
    	From = ZoomDateStart.Ticks,
    	To = ZoomDateEnd.Ticks
    };
    
    cartesianChart1.AxisX[0].SetBinding(Axis.MinValueProperty,
    	new Binding { Path = new PropertyPath("From"), Source = assistant, Mode = BindingMode.TwoWay });
    cartesianChart1.AxisX[0].SetBinding(Axis.MaxValueProperty,
    	new Binding { Path = new PropertyPath("To"), Source = assistant, Mode = BindingMode.TwoWay });
