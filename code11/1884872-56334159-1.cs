    public IEnumerable<Detail> Parse(string source,char delimiter)
    {
    	return source.Split(new []{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries)
    		  .Skip(1)
    		  .Select(x=> 
    		  {
    		  	var detail = x.Split(new []{delimiter});
    			return new Detail
    			{
    				FamilyID = Int32.Parse(detail[0]),
    				Name = detail[1],
    				Gender = detail[2],
    				DOB = DateTime.Parse(detail[3]),
    				PlaceOfBirth = detail[4],
    				Status = detail[5]
    			};
    		  }
    		  );
    	
    }
