    public class BoxImageViewDetailDto
    {
        public Guid PropertyId { get; set; }
    
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string SubDescription { get; set; }
    
        public decimal? PropertyValue { get; set; }
        public byte? UnitsFloor { get; set; }
    
        public dynamic ImagensRowsVar { get; set; }
        public List<ImageViewDto> ImagensRows 
        {
            get
            {
                return (List<ImageViewDto>)this.ImagensRowsVar; 
            }
        }
    
        public int ImagensRowsTotal { get; set; }
    }
    CorretorDaVez.DTO.UserControls.BoxImageViewDetailDto c = (from p in entities.rlt_Property
	  join pc in entities.rlt_PropertyPicture on p.PropertyId equals pc.PropertyId
	  where p.PropertyId == propertyId
	  orderby p.CreateDate descending
	  select new CorretorDaVez.DTO.UserControls.BoxImageViewDetailDto
	  {
		  PropertyId = p.PropertyId,
		  Title = p.Title,
		  PropertyValue = p.PropertyValue,
		  Description = p.Description,
		  UnitsFloor = p.UnitsFloor,
		  ImagensRowsTotal = p.rlt_PropertyPicture.Count,
		  ImagensRowsVar = p.rlt_PropertyPicture.Select(s => new CorretorDaVez.DTO.UserControls.ImageViewDto { PropertyId = p.PropertyId, ImagePath = pc.PhotoUrl})
	  }).FirstOrDefault();
