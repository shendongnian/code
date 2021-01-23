    namespace CL
        {
            public class Item
            {
                public static implicit operator Item(DB.Item db)
                {
                    return new Item
                    {
                        Created = db.Created,
                        Id = db.ItemId
                    };
                }
            }
        }
