      var query =
                        from DT1Row in DT1.AsEnumerable()
        			    from DT2Row in DT2.AsEnumerable()
        				where DT1Row.Field<int>("crsnum") = DT2Row.Field<int>("crsnum")
        				and DT1Row.Field<int>("crsnum_e") = DT2Row.Field<int>("crsnum_e")
        				and DT1Row.Field<int>("crstteng") = DT2Row.Field<int>("crstteng")				
        				select DT1Row;
        			
       DataTable resultDataTable = query.CopyToDataTable();
