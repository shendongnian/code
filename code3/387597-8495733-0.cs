        [CollectionDataContract(ItemName="element", Name = "elementCollection")]
        public class DataResponse<T> : List<T>
        {
            public DataResponse() : base()
            {
            }
            public DataResponse(List<T> list) : base()
            {
                this.AddRange(list);        
            }
        }
