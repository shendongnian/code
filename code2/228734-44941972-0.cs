    public struct DisplayOptions
    {
        public bool isUpon;
        public bool screenFade;
        public static DisplayOptions Build()
        {
            // Return default value
            return new DisplayOptions(true, true);
        }
        DisplayOptions(bool isUpon, bool screenFade)
        {
            this.isUpon = isUpon;
            this.screenFade = screenFade;
        }
        public DisplayOptions SetUpon(bool upon)
        {
            this.isUpon = upon;
            return this;
        }
        public DisplayOptions SetScreenFade(bool screenFade)
        {
            this.screenFade = screenFade;
            return this;
        }
    }
