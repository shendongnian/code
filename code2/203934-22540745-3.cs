    for (TrayLevelCodes trayLevelCode = TrayLevelCodes._5DGS; trayLevelCode <= TrayLevelCodes._MADC; trayLevelCode++)
    				{
    
    					IEnumerable<System.Linq.IGrouping<string, CommonShared.DropShipRecord>> TrayLvLst = (from i in pair1.Value.AutoMap
    																					where (i.TrayLevelCode == HTMLINFO.GetCntnrLvlDscptn(trayLevelCode))
    																					orderby i.TrayZip, i.GroupZip
    																					group i by i.TrayZip into subTrayLvl
    																					select subTrayLvl).ToList();
    					foreach (DropShipRecord tray in TrayLvLst)
    					{
    						
    					}
    				}
