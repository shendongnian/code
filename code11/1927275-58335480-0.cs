    class HeaderDetails : BindableObject {
        
        public List<Detail> DetailsForThisId { get; set; }
        public int Id { get; set; }
    
        public HeaderDetails(int headerId) {
           Id = headerId;
           DetailsForThisId = GetDetailItemsForId(headerId); //This method queries your SQLite details table based on given Id.
        }
    
    }
