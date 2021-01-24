    void Main()
    {	
    	DateTime today = DateTime.Now;	
    	List<Material> materials = new List<UserQuery.Material>();
    
    	materials.Add(new Material { Hours = 6 });
    	materials.Add(new Material { Hours = 2 });
    	materials.Add(new Material { Hours = -6 });
    	materials.Add(new Material { Hours = -6 });
    	materials.Add(new Material { Hours = 4 });
    
        // normal version
		var materialsByExpiry = (from m in materials
								where m.ExpiryDate() >= today
								orderby m.ExpiryDate()
								select m).ToList();
    						
    	Material.count.Dump("COUNT normal");
    	Material.count = 0;
    
        // LET version
    	var materialsByExpiry_Let = (from m in materials
    							let date = m.ExpiryDate() 
    							where date >= today
    							orderby date
    							select m).ToList();
    
    	Material.count.Dump("COUNT using LET");
    	materialsByExpiry.Dump();
    	materialsByExpiry_Let.Dump();
    }
    
    public class Material
    {
    	public static int count = 0;
    	public int Hours { get; set; }
    	public DateTime ExpiryDate()
    	{
    		count++;
    		return DateTime.Now.AddHours(Hours);
    	}
    }
