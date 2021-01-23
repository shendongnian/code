      private class CopierField
      {
         // Name of the field or property and a reference to the declaring Type
         public string MemberName;
         public Type DeclaringType;
         // Reference to the FieldInfo or PropertyInfo object for this field or property. One of 
         //  these will be null and the other non-null.
         public FieldInfo MemberInfoForField = null;
         public PropertyInfo MemberInfoForProperty = null;
         // Ordering of this field, as returned by Type.GetMembers(). This is only used while 
         //  building the List<> of these objects for XML serialization
         public int FieldOrder;
         /// <summary>
         /// Comparison method that can be used to sort a collection of CopierField objects so they 
         /// are in the order wanted for XML serialization. This ordering is dependent on the depth 
         /// of derivation, and when that is equal it maintains the original ordering.
         /// </summary>
         public static readonly Comparison<CopierField> CompareForXml =
                            delegate(CopierField a, CopierField b)
                            {
                               int aDepth = GetTypeDepth(a.DeclaringType);
                               int bDepth = GetTypeDepth(b.DeclaringType);
                               if (aDepth != bDepth)
                                  return aDepth.CompareTo(bDepth);
                               return a.FieldOrder.CompareTo(b.FieldOrder);
                            };
         /// <summary>
         /// Method to determine the depth of derivation for a type.
         /// </summary>
         private static int GetTypeDepth(Type aType)
         {
            int i = 0;
            while (aType.BaseType != null)
            {
               i++;
               aType = aType.BaseType;
            }
            return i;
         }
      }
