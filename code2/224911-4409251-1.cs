    namespace CL.DB
    {
        public partial class Item
            {
                public static implicit operator CL.Item(Item db)
                {
                   
                    return new CL.Item
                    {
                        Created = db.Created,
                        Id = db.ItemId
                    };
                }
            }
    }
