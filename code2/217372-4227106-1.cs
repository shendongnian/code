    public class MyObject {
        private IList<DataTable> _measurementErrors;
        public MyObject() {
            _measurementErrors = new List<DataTable>();
        }
        // This way you make sure to never have a null reference, and don't give 
        // out the control over your list to the user.
        public IList<DataTable> MeasurementErrors {
            get {
                return _measurementErrors;
            }
        }
    }
