void AddMany(int id, IEnumerable<dynamic> objectsToAdd) {
   // Create an empty list for the given key if it doesn't exist
   if (!dictionary.ContainsKey(id)) {
      dictionary[id] = new List<dynamic>();
   }
   dictionary[id].AddRange(objectsToAdd);
}
If you are just adding a single item:
void AddOne(int id, dynamic objectToAdd) {
   // Create an empty list for the given key if it doesn't exist
   if (!dictionary.ContainsKey(id)) {
      dictionary[id] = new List<dynamic>();
   }
   dictionary[id].Add(objectToAdd);
}
