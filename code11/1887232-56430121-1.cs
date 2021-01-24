    public static int GetPropertyHash(Type type) {
        int hash = 237463;
        foreach (PropertyInfo prop in type.GetProperties()) {
            unchecked {
                hash = hash * 17 + prop.Name.GetHashCode();
                hash = hash * 17 + prop.PropertyType.FullName.GetHashCode();
            }
        }
        return hash;
    }
