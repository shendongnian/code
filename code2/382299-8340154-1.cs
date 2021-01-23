        public class ListItem : ListItem<object>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ListItem"/> class.
            /// </summary>
            /// <param name="key"></param>
            /// <param name="description"></param>
            public ListItem( object key, string description )
                : base (key, description)
            {
            }
        }
