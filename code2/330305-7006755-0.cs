                // if there are no GC references in this object we can avoid reflection
                // and do a fast memcmp 
                if (CanCompareBits(this))
                    return FastEqualsCheck(thisObj, obj); 
     
                FieldInfo[] thisFields = thisType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
     
                for (int i=0; i<thisFields.Length; i++) {
                    thisResult = ((RtFieldInfo)thisFields[i]).InternalGetValue(thisObj,false);
                    thatResult = ((RtFieldInfo)thisFields[i]).InternalGetValue(obj, false);
     
                    if (thisResult == null) {
                        if (thatResult != null) 
                            return false; 
                    }
                    else 
                    if (!thisResult.Equals(thatResult)) {
                        return false;
                    }
                } 
