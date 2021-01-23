    //Get the list of installed sound devices. 
    sdl = new IrrKlang.ISoundDeviceList(IrrKlang.SoundDeviceListType.PlaybackDevice);
    //Add each device to a combo box.
    for(int i = 0; i < sdl.DeviceCount; i++)
    {
        comboBox1.Items.Add(sdl.getDeviceDescription(i) + "\n");
    }
    //Place this code in your play sound event handler.
    //Create a sound engine for the selected device (uses the ComboBox index to 
    //get device ID).
    irrKlangEngine = new IrrKlang.ISoundEngine(IrrKlang.SoundOutputDriver.AutoDetect,
    				IrrKlang.SoundEngineOptionFlag.DefaultOptions, 
                    sdl.getDeviceID(comboBox1.SelectedIndex));
    				
    //Play the selected file
    playSelectedFile(fileName);
