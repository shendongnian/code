    var midiFile = MidiFile.Read("Greatest song ever.mid");
    
    // Or you can read a MIDI file from a stream
    // var midiFile = MidiFile.Read(stream);
    
    using (var outputDevice = OutputDevice.GetByName("Microsoft GS Wavetable Synth"))
    {
        midiFile.Play(outputDevice);
    }
