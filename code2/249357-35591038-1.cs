      [StructLayout(LayoutKind.Explicit)]
      public struct ConvertHelper<TFrom, TTo>
          where TFrom : class
          where TTo : class {
        [FieldOffset( 0)] public long before;
        [FieldOffset( 8)] public TFrom input;
        [FieldOffset(16)] public TTo output;
    
        static public TTo Convert(TFrom thing) {
          var helper = new ConvertHelper<TFrom, TTo> { input = thing };
          unsafe {
            long* dangerous = &helper.before;
            dangerous[2] = dangerous[1];  // ie, output = input
          }
          var ret = helper.output;
          helper.input = null;
          helper.output = null;
          return ret;
        }
      }
    
      class PublicList<T> {
        public T[] _items;
      }
    
      public static T[] GetBackingArray<T>(this List<T> list) {
        return ConvertHelper<List<T>, PublicList<T>>.Convert(list)._items;
      }
