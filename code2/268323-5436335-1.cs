    List<Input> inputs = new List<Input>();
    Input x = new Input() { InputType = InputType.Digital };
    x.RackTemperature = new Temperature { Parameter = "P", Label = "L" };
    x.ProbeTemperature = new Temperature { Parameter = "P', Label = "L" };
   
    inputs.Add(x);
