    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    //  The purpose of this class is to provide a dictionary with auto-vivification behaviour similar to Perl's
    //  Using dict[index] will succeed regardless of whether index exists in the dictionary or not.
    //  A default value can be set to be used as an initial value when the key doesn't exist in the dictionary
    
    namespace XMLTest 
    {
        class AutoDictionary<TKey,TValue> : Dictionary<TKey,TValue> {
    
            Object DefaultValue ;
    
            public AutoDictionary(Object DefaultValue) {
                this.DefaultValue = DefaultValue;
            }
    
            public AutoDictionary() {
                this.DefaultValue = null;
            }
    
            public new TValue this[TKey index] {
                get {
                    try {
                        return base[index];
                    }
                    catch (KeyNotFoundException) {
                        base.Add(index, (TValue)DefaultValue);
                        return (TValue)DefaultValue ;
                    }
                }
    
                set {
                    try { 
                        base[index] = value ;
                    }
                    catch (KeyNotFoundException) {
                        base.Add(index, value);
                    }
                }
    
            }
        }
    }
