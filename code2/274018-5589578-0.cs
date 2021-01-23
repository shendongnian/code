    class MyDataHolder {
        int numberOfSiblings = -1;
        public property int NumberOfSiblings {
            get {
                ClearData();
                numberOfSiblings = value;
            }
        }
    
        DateTime dateOfBirth = null;
        public property DateTime DateOfBirth {
            get {
                ClearData();
                dateOfBirth = value;
            }
        }
    
        String name = null;
        public property String Name {
            get {
                ClearData();
                name = value;
            }
        }
    
    
        private void ClearData() {
            numberOfSiblings = -1;
            dateOfBirth = null;
            name = null;
        }
    
    
        public object GetData() {
            if (numberOfSiblings != -1) {
                return numberOfSiblings;
            }
            else if (dateOfBirth != null) {
                return dateOfBirth;
            }
            else if (name != null) {
                return name;
            }
    
            return null;
        }
    }
