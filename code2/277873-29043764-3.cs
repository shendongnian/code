    public class YearsCbo : ComboBox //Inherits ComboBox
    {
        public YearsCbo() { 
            fill();
        }
        private void fill() { // <<<=== THIS METHOD ADDED ITEMS TO THE COMBOBOX
            for(int idx = 0; idx < 25; idx++) {
                this.Items.Add(new YearItem());
            }
        }
        // Other code not shown
        private class YearItem {} // <<<=== The VS designer can't access this class and yet 
            // it generated code to try to do so.  That code then fails to compile.
            // The compiler error rightfully says it is unable to access 
            // the private class YearItem
    }
