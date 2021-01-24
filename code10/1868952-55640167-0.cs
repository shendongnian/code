    public List<House> housesList;
    	int currentIndex = 0;
    	
        public HouseList()
        {
            housesList = new List<House>();
            housesList.Add(new House()
            {
                Address = "35 Twin Oaks",
                City = "Glendale",
                Zip = "MDN6L3",
                AskingPrice = "328,743.00",
                PictureFile = "",
                AveragePrice = "490,747.80",
                Total = "2,453,739.00"
            });
    
    
            housesList.Add(new House()
            {
                Address = "35 Helen Drive",
                City = "OakDale",
                Zip = "G6L5M4",
                AskingPrice = "455,899.00",
                PictureFile = "",
                AveragePrice = "490,747.80",
                Total = "2,453,739,00"
            });
    
            housesList.Add(new House()
            {
                Address = "4 RiverBank Rd",
                City = "Brampton",
                Zip = "L9H4L2",
                AskingPrice = "699,999.00",
                PictureFile = "",
                AveragePrice = "490,747.80",
                Total = "2,453,739,00"
            });
        }
    
        public House NextHouse()
        {
            return housesList[(++currentIndex)%housesList.Count()];
        }
