    class Program {
        static void Main( string[] args ) {
            var items = Item.GetItems();
            // mind the case where index == 0 so you don't grab an item out of bounds
            var ind = GetIndices( items,
                ( p, index ) => ( h.index == 0 ) ? false : p.Height < items[ index - 1 ].Height );
        }
        static List<int> GetIndices<T>( List<T> list, Func<T, int, bool> condition ) {
            var res = list
                .Select( ( item, index ) => new { item, index } ) // capture original index
                .Where( h => condition( h.item, h.index ) )
                .Select( h => h.index ); // reduce to the index again
            return res.ToList();
        }
    }
    class Item {
        public int Height {
            get;
            set;
        }
        public Item( int h ) {
            Height = h;
        }
        static public List<Item> GetItems() {
            return new List<Item>( new[]{
                         new Item(1),
                         new Item(4),
                         new Item(2),
                         new Item(5)
            } );
        }
    }
