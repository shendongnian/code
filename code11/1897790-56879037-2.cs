    public class Humans {
        // These variables are accessible only by code within this class block.
        private string firstName;
        private string lastName;
        
        // This constructor is public, so it could be accessed anywhere.
        public Humans(string firstName, string lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        // This function is public, so can be called to get the full name.
        public string getFullName() {
            // the variable fullName only exists in the scope of this function.
            // so there is no point in applying an access modifier.
            string fullName = String.format("{} {}", this.firstName, this.lastName);
            // When we return fullName, we return a copy of the value, and the 
            // original variable gets cleaned up.
            return fullName;
        }
        // Lets say we want to allow updating the name, but we want to verify
        // that the name is valid first. We can make public setters.
        public void setFirstName(String firstName) {
            if (!String.isNullOrWhiteSpace(firstName)) {
                this.firstName = firstName;
            } else {
                throw new InvalidArgumentException("First name cannot be null or empty.")
            }
        }
    }
