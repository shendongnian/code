    using System; // For the Random
    using System.Collections.Generic; // The List
    
    // List:
    List<ItemType> list = new List<ItemType>();
    
    // Add x:
    ItemType x = ...; // The item to insert into the list
    list.Add( x );
    
    // Random selection
    Random r = ...; // Probably get this from somewhere else
    int index = r.Next( list.Count );
    ItemType y = list[index];
    
    // Remove item at index
    list[index] = list[list.Count - 1]; // Copy last item to index
    list.RemoveAt( list.Count - 1 ); // Remove from end of list
