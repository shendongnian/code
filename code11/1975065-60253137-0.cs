            public void Play()
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                string[] resources = assembly.GetManifestResourceNames();
                foreach (string resource in resources)
                {
                    if (resource.Contains("emailalert.wav"))
                    {
                        Stream stream = assembly.GetManifestResourceStream(resource);
                        if (stream != null)
                        {
                            var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                            audio.Load(stream);
                            audio.Play(); break;
                        }
                    }
                }
            }
