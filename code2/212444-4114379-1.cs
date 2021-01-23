    Program.sp.SoundLocation = System.IO.Path
                        .GetDirectoryName(System.Reflection.Assembly
                                .GetExecutingAssembly().Location)
                        + "/aimlife_success.wav";
                Program.sp.Play();
