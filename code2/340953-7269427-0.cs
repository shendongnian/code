    public static DataTable mdlform_NewMBUStele(int LoggerID, List<MbusTelegram> mList, DataTable _deviceDataTable){
                //TODO Das ist total dirty und gar nicht clean hier...
                foreach (DataRow dRow in _deviceDataTable.Rows){
                    if (dRow.ItemArray[3] is Slave){
                        var primeID = (int) dRow.ItemArray[1];
                        var slv = (Slave) dRow.ItemArray[3];
                        if (slv.ListOfTelegramms == null){
                            slv.ListOfTelegramms = new List<MbusTelegram>();
                        }
                        var list = slv.ListOfTelegramms;
                        if (primeID == LoggerID){
                            foreach (var mbus in mList.Where
                                (m => slv.PrimeAddress == m.Header.PrimeAddress &&
                                      slv.SecondaryAdd == m.FixedDataHeader.SecondaryAddress)){
                                if (!list.Contains(mbus)){
                                    list.Add(mbus);
                                    //TODO Check if the slave already contains the telegramm, if so don't add it..
                                }
                            }
                        }
                    }
                }
                return _deviceDataTable;
            }
