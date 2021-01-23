                IEnumerable<DataRow> test =
                from t in dt.AsEnumerable()
                where Convert.ToInt32(t["T_TEMPLATE_ID"]) == iTemplateId
                select t;
                if(test.count() > 0)
                {
                //recods Found!
                DataTable boundTable  = test.CopyToDataTable<DataRow>();
                }
                else
                {
                  //no Recods found!
                }
