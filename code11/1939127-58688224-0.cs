     public List<SelectListItem> Travel_Agent()
            {
                var unitcode = Convert.ToInt32(HttpContext.Session.GetString("UnitCode"));
                string sqlquery = "  select supp_code,supp_name from li_supplier_msts  ";
                DataTable dtDRP_VALUE = _context.GetSQLQuery(sqlquery);
                List<SelectListItem> DRP_VALUE = new List<SelectListItem>();
                DRP_VALUE = (from DataRow dr in dtDRP_VALUE.Rows
                             select new SelectListItem()
                             {
                                 Value = Convert.ToString(dr["supp_code"]),
                                 Text = Convert.ToString(Convert.ToString(dr["supp_code"] + "~" + dr["supp_name"]  ))
                             }).ToList();
    
                return DRP_VALUE;
    
            }
