    pi@raspberrypi:/tmp $ cat f
    public static class AppConfig
    {
        public static bool FirstClass = false;
    }
    pi@raspberrypi:/tmp $ sed -i  's/FirstClass =[ ]*false/FirstClass = true/' f
    pi@raspberrypi:/tmp $ cat f
    public static class AppConfig
    {
        public static bool FirstClass = true;
    }
