    public static IEnumerable<ObjectFromVdCruijsen> FilteredByNome(this IEnumerable<ObjectFromVdCruijsen> enumerable, string name){
        if (!string.IsNullOrEmpty(name)){
                enumerable = enumerable.Where(s => s.Name.ToUpperInvariant().Contains(name.ToUpperInvariant()));
        }
        return enumerable;
    }
 
