            var RateForDate = 20190701;
            ECCDestinationConfig cfg = new ECCDestinationConfig();
            RfcDestinationManager.RegisterDestinationConfiguration(cfg);
            RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
            RfcRepository repo = dest.Repository;
            IRfcFunction sapFunction = repo.CreateFunction("RFC_READ_TABLE");
            sapFunction.SetValue("QUERY_TABLE", "TCURR");
            // fields will be separated by semicolon
            sapFunction.SetValue("DELIMITER", ";");
            // Parameter table FIELDS contains the columns you want to receive
            // here we query 3 fields, FCURR, TCURR and UKURS
            IRfcTable fieldsTable = sapFunction.GetTable("FIELDS");
            fieldsTable.Append();
            fieldsTable.SetValue("FIELDNAME", "FCURR");
            //fieldsTable.Append();
            //fieldsTable.SetValue("FIELDNAME", "TCURR");
            //fieldsTable.Append();
            //fieldsTable.SetValue("FIELDNAME", "UKURS");
            // the table OPTIONS contains the WHERE condition(s) of your query
            // here a single condition, KUNNR is to be 0012345600
            // several conditions have to be concatenated in ABAP syntax, for instance with AND or OR
            IRfcTable optsTable = sapFunction.GetTable("OPTIONS");
            var dateVal = 99999999 - RateForDate;
            optsTable.Append();
            optsTable.SetValue("TEXT", "gdatu = '" + dateVal + "' and KURST = 'EURX'");
            sapFunction.Invoke(dest);
            var companyCodeList = sapFunction.GetTable("DATA");
            DataTable Currencies = companyCodeList.ToDataTable("DATA");
            //Add additional column for rates
            Currencies.Columns.Add("Rate", typeof(double));
            //------------------
            sapFunction = repo.CreateFunction("BAPI_EXCHANGERATE_GETDETAIL");
            //rate type of your system
            sapFunction.SetValue("rate_type", "EURX");
            sapFunction.SetValue("date", RateForDate.ToString());
            //Main currency of your system
            sapFunction.SetValue("to_currncy", "EUR");
            foreach (DataRow item in Currencies.Rows)
            {
                sapFunction.SetValue("from_curr", item[0].ToString());
                sapFunction.Invoke(dest);
                IRfcStructure impStruct = sapFunction.GetStructure("EXCH_RATE");
                item["Rate"] = impStruct.GetDouble("EXCH_RATE_V");
            }
            dtCompanies.DataContext = Currencies;     
            RfcDestinationManager.UnregisterDestinationConfiguration(cfg);
