     [WebMethod]
            public JsonResult LoadRegion(string zoneCode)
            {
                ArrayList arl = new ArrayList();
    
                RASolarERPData objDal = new RASolarERPData();
                List<tbl_Region> region = new List<tbl_Region>();
    
                region = erpDal.RegionByZoneCode(zoneCode);
    
                foreach (tbl_Region rg in region)
                {
                    arl.Add(new { Value = rg.Reg_Code.ToString(), Display = rg.Reg_Name });
                }
    
                return new JsonResult { Data = arl };
            }
