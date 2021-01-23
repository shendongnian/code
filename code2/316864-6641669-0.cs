    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    // This class represents a very simple keyed list of OrderItems,
    // inheriting most of its behavior from the KeyedCollection and 
    // Collection classes. The immediate base class is the constructed
    // type KeyedCollection<int, OrderItem>. When you inherit
    // from KeyedCollection, the second generic type argument is the 
    // type that you want to store in the collection -- in this case
    // OrderItem. The first type argument is the type that you want
    // to use as a key. Its values must be calculated from OrderItem; 
    // in this case it is the int field PartNumber, so SimpleOrder
    // inherits KeyedCollection<int, OrderItem>.
    //
    public class SimpleOrder : KeyedCollection<int, OrderItem>
    {
        // The parameterless constructor of the base class creates a 
        // KeyedCollection with an internal dictionary. For this code 
        // example, no other constructors are exposed.
        //
        public SimpleOrder() : base() {}
    
        // This is the only method that absolutely must be overridden,
        // because without it the KeyedCollection cannot extract the
        // keys from the items. The input parameter type is the 
        // second generic type argument, in this case OrderItem, and 
        // the return value type is the first generic type argument,
        // in this case int.
        //
        protected override int GetKeyForItem(OrderItem item)
        {
            // In this example, the key is the part number.
            return item.PartNumber;
        }
    }
