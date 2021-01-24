    class Test
        {
            public void TestMethod()
            {
                var repo = new Repository();
                var result = repo.tbl_brand
                       .Select(b => new NetNewsCounts()
                       {
                           BrandID = b.OID,
                           ResultCount = repo.tbl_result_subject_brand.Count(rb => rb.brand_id == b.OID)
                       }).ToList();
            }
    
            private class Brand
            {
                public string OID { get; set; }
            }
    
            private class ResultBrand
            {
                public string brand_id { get; set; }
            }
    
            private class Repository
            {
                public List<Brand> tbl_brand { get; set; }
                public List<ResultBrand> tbl_result_subject_brand { get; set; }
            }
    
            private class NetNewsCounts
            {
                public string BrandID { get; set; }
    
                public int ResultCount { get; set; }
            }
        }
