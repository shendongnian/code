        private static string[] AddSettings(ref string[] settings, params string[] SettingsToAdd)
        {                   
            int length = SettingsToAdd.Length;
            if (length%2 !=0)
            {
                throw new ArgumentException("Invalid number of elements");
            }
            int OldLength = settings.Length;
            int NewLength = settings.Length + length;
            Array.Resize(ref settings, NewLength);
            for (int i = OldLength; i < NewLength; i++)
            {
                settings[i] = SettingsToAdd[i - OldLength];
            }
            return settings;
        }
