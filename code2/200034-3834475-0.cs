    using System;
    using System.Collections.Generic; 
    
    public sealed class Contact : IEquatable<Contact>
    {
        private readonly string firstName;
        public string FirstName { get { return firstName; } }
        
        private readonly string lastName;
        public string LastName { get { return lastName; } }
    
        private readonly string phoneNumber;
        public string PhoneNumber { get { return phoneNumber; } }
        
        public Contact(string firstName, string lastName, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }
        
        public override bool Equals(object other)
        {
            return Equals(other as Contact);
        }
        
        public bool Equals(Contact other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(other, this))
            {
                return true;
            }
            return FirstName == other.FirstName &&
                   LastName == other.LastName &&
                   PhoneNumber == other.PhoneNumber;
        }
        
        public override int GetHashCode()
        {
            // Note: *not* StringComparer; EqualityComparer<T>
            // copes with null; StringComparer doesn't.
            var comparer = EqualityComparer<string>.Default;
            
            // Unchecked to allow overflow, which is fine
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + comparer.GetHashCode(FirstName);
                hash = hash * 31 + comparer.GetHashCode(LastName);
                hash = hash * 31 + comparer.GetHashCode(PhoneNumber);
                return hash;
            }
        }
    }
