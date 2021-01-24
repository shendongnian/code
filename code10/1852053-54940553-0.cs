    public class SaleCenterViewModel
    {
        public string Title { get; set; }
        public string TitleEN { get; set; }
        public int Code { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AddressEN { get; set; }
        public static SaleCenterViewModel Set(SaleCenter saleCenter)
        {
            return new SaleCenterViewModel
            {
                Title = saleCenter.Title,
                TitleEN = saleCenter.TitleEN,
                Code = saleCenter.Code,
                Lat = saleCenter.Lat,
                Lng = saleCenter.Lng,
                Phone = saleCenter.Phone,
                Address = saleCenter.Address,
                AddressEN = saleCenter.AddressEN
            };
        }
    }
