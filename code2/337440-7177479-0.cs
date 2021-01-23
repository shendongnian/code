    class Statistician
    {
        public bool MustCalculateFIRSTSTATISTIC { get; set; }   // Please rename me!
        public bool MustCalculateSECONDSTATISTIC { get; set; }  // Please rename me!
        public void ProcessObject(object Object) // Replace object and Rename
        {
            if (MustCalculateFIRSTSTATISTIC)
                CalculateFIRSTSTATISTIC(Object);
            if (MustCalculateFIRSTSTATISTIC)
                CalculateSECONDSTATISTIC(Object);
        }
        public object GetFIRSTSTATISTIC() // Replace object, Rename
        { /* ... */ }
        public object GetSECONDSTATISTIC() // Replace object, Rename
        { /* ... */ }
        private void CalculateFIRSTSTATISTIC(object Object) // Replace object
        { /* ... */ }
        private void CalculateSECONDSTATISTIC(object Object) // Replace object
        { /* ... */ }
    }
