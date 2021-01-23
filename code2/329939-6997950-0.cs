    var normalSearch = getDuplicates().ToArray().Cast<Clients>();
    var client = getClients().ToArray();
    
    var unique = client.Union(normalSearch, new ClientsComparer());
    
    public class ClientsComparer : IEqualityComparer<Clients>
    {
        public bool Equals(Clients x, Clients y)
        {
    
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            //Check whether the products' properties are equal.
            return x.ContactId == y.ContactId;
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public int GetHashCode(Client client)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(product, null)) return 0;
    
            //Calculate the hash code for the product.
            return client.ContactId.GetHashCode();
        }
    
    }
