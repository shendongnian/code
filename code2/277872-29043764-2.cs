    public class YearsCbo : ComboBox //Inherits ComboBox
    {
        public YearsCbo() { 
            if ( ! HostedDesignMode ) {
                fill();
            }
        }
        private class YearItem {} // <<<=== Now the VS Designer does not try to access this
    }
