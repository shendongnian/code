    public static DataTable mdlform_NewMBUStele(int LoggerID, List<MbusTelegram> mList, DataTable _deviceDataTable){
                //TODO Das ist total dirty und gar nicht clean hier...
                foreach (DataRow dRow in _deviceDataTable.Rows.Cast<DataRow>().Where(d=>d.ItemArray[3] is Slave)){
                        var primeID = (int) dRow.ItemArray[1];
                        var slv = (Slave) dRow.ItemArray[3];
                        if (slv.ListOfTelegramms == null){
                            slv.ListOfTelegramms = new List<MbusTelegram>();
                        }
                        var list = slv.ListOfTelegramms;
                        if (primeID == LoggerID){
                            var items = from m in mList
                                        where
                                            slv.PrimeAddress == m.Header.PrimeAddress &&
                                            slv.SecondaryAdd == m.FixedDataHeader.SecondaryAddress && !list.Contains(m, MbusTelegramEqualityComparer.Default)
                                        select m;
                            list.AddRange(items.Distinct(MbusTelegramEqualityComparer.Default));
                            }
                        }
                return _deviceDataTable;
            }
