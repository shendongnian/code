    using (var midiStream = new MemoryStream(Resources.myMidi))
            {
                var data = midiStream.ToArray();
                try
                {
                    using (var fs = new FileStream("midi.mid", FileMode.CreateNew, FileAccess.Write))
                    {
                        fs.Write(data, 0, data.Length);
                    } 
                }
                catch(IOException)
                {}
                string sCommand = "open \"" + Application.StartupPath + "/midi.mid" + "\" alias " + "MIDIapp";
                mciSendString(sCommand, null, 0, IntPtr.Zero);
                sCommand = "play " + "MIDIapp";
                mciSendString(sCommand, null, 0, IntPtr.Zero);
            }
