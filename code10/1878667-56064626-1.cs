    public static class BinaryReaderExtension {
        private static Dictionary <short, Func <Building>> generators = new Dictionary <short, Func <Building>> ();
        static BinaryReaderExtension () {
            generators [0] = () => new Farm ();
            generators [1] = () => new Mill ();
        }
        
        public static Building ReadBuilding (this BinaryReader reader) {
            var b = generators [reader.ReadInt16 ()] ();
            b.ReadMembers (reader);
            return b;
        }
    }
