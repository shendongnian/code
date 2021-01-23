    using System;
    class Settings {
        public int ValueA { get; set; }
        public string ValueB { get; set; }
        public void CopySettings(Settings other) {
            ValueA = other.ValueA;
            ValueB = other.ValueB;
        }
    }
    class Program {
        static void Main(string[] args) {
            Settings a = new Settings() { ValueA = 3, ValueB = "something" };
            Settings b = new Settings();
            // and then you can do one the following, which will copy all settings
            // in both cases...
            b.CopySettings(a);
            a.CopySettings(b);
        }
    }
