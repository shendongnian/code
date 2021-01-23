    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    namespace CloudOne.Models
    {
    	public class Brand
    	{
    		public int BrandID { get; set; }
    		[MaxLength(25)]
    		[Required]
    		public string BrandName { get; set; }
    		[MaxLength(1000)]
    		public string BrandDescription { get; set; }
    		public int SortOrder { get; set; }
    		//SEO
    		[MaxLength(70)]
    		public string PageTitle { get; set; }
    		[MaxLength(100)]
    		public string MetaDescription { get; set; }
    		[MaxLength(150)]
    		public string MetaKeywords { get; set; }
    		[MaxLength(56)]	//50 + "-" + 99,000
    		public string Slug { get; set; }
    	}
    }
