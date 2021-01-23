    private void FilterBasedUponPermission(List<Data.Indications.SpWeb_SavedIndications1LightDataObject> list)
            {
                list.RemoveAll(item =>
                    (item.Permission == null) ||
                    (item.Permission == Controllers.Indications.ICConstants.TradeType_LLH && !isLLH) ||
                    (item.Permission == Controllers.Indications.ICConstants.TradeType_ALM && !isALM) ||
                    (item.Permission == Controllers.Indications.ICConstants.TradeType_RealEstate && !isRE) ||
                    (item.Permission == Controllers.Indications.ICConstants.TradeType_Auditor && !isAuditor));
            }
