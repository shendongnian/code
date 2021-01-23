    // Create the hidden control
    Control hiddenControl = new Control();
    control.Width = width;
    control.Height = height;
    control.Visible = false;         // Just for good measure, it wouldn't be displayed anyways
    // Present Parameters
    PresentParamaters presentParams = new PresentParamaters();
    presentParams.SwapEffect = SwapEffect.Discard;
    presentParams.Windowed = true;
    // Create the device
    Device device = new Device(0, DeviceType.Hardware, hiddenControl, CreateFlags.SoftwareVertexProcessing, presentParams);
