    public static class Settings
    {
        private static int trk5;
        public static int Trk5
        {
            get { return trk5; }
            set
            {
                if (trk5 != value)
                {
                    trk5 = value;
                    db2.Update(new Setting { "Trk5", Value = value.ToString() });
                }
            }
        }
    }
    
    Settings.Trk5 = 2;
