    public struct Unit {
        public static readonly Unit Inches = new Unit(16, "\"");
        public static readonly Unit Centimeters = new Unit(10, "cm");
        private readonly int _unitBase;
        private readonly string _unitLabel;
        static Unit() { }
    
        private Unit(int unitBase, string unitLabel) {
            this._unitBase = unitBase;
            this._unitLabel = unitLabel;
        }
        public int UnitBase {
            get { return this._unitBase; }
        }
        public string UnitLabel {
            get { return this._unitLabel; }
        }
    }
