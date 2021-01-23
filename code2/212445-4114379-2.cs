     RechargeStatus = "Failed";
                Program.sp.SoundLocation = System.IO.Path
                        .GetDirectoryName(System.Reflection.Assembly
                                .GetExecutingAssembly().Location)
                        + "/aimlife_error.wav";
                Program.sp.Play();
