        public class ListItem<TKey> : IComparable<ListItem<TKey>>
        {
            /// <summary>
            /// Gets or sets the data that is associated with this ListItem instance.
            /// </summary>
            public TKey Key
            {
                get;
                set;
            }
    
            /// <summary>
            /// Gets or sets the description that must be shown for this ListItem.
            /// </summary>
            public string Description
            {
                get;
                set;
            }
    
            /// <summary>
            /// Initializes a new instance of the ListItem class
            /// </summary>
            /// <param name="key"></param>
            /// <param name="description"></param>
            public ListItem( TKey key, string description )
            {
                this.Key = key;
                this.Description = description;
            }
    
            public int CompareTo( ListItem<TKey> other )
            {
                return Comparer<String>.Default.Compare (Description, other.Description);
            }
       
            public override string ToString()
            {
                return this.Description;
            }
        }
