    public static DataTable mdlform_NewMBUStele2(int LoggerID, List<MbusTelegram> mList, DataTable _deviceDataTable){
                var pairs = from dRow in _deviceDataTable.Rows.Cast<DataRow>()
                            where dRow.ItemArray[3] is Slave
                            let primeID = (int) dRow.ItemArray[1]
                            let slv = (Slave) dRow.ItemArray[3]
                            let list = slv.ListOfTelegramms
                            where primeID == LoggerID
                            select
                                new{
                                       list,
                                       items = (from m in mList
                                                where
                                                    slv.PrimeAddress == m.Header.PrimeAddress &&
                                                    slv.SecondaryAdd == m.FixedDataHeader.SecondaryAddress &&
                                                    !list.Contains(m, MbusTelegramEqualityComparer.Default)
                                                select m).Distinct(MbusTelegramEqualityComparer.Default)
                                   };
                foreach (var pair in pairs){
                    pair.list.AddRange(pair.items);
                }
                return _deviceDataTable;
            }
