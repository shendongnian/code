    public List<Result> GetCount()
            {
                using (MuleContext db = new MuleContext())
                {
    
    
                    var list = db.tbl_brand.Tolist();
                    List<Result> GN = new List<Result>();
                    foreach (var n in list)
                    {
                        Result Notif = new Result()
                        {
                            OID = n.OID,
                            
                       ResultCount=db.tbl_result_subject_brand.where(t=>t.brand_id=n.OID)
                        };
                        GN.Add(Notif);
                    }
                    return GN;
                }
            }
