    public List<string> ParseLot()
        {
            var lotList = new List<string>();
            var establishmentList = GetEstablishmentCode();
            foreach (var lot in GetBarcodeList())
            {
                if (establishmentList.Contains("038"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.LoganSport038Property);
                }
                if (establishmentList.Contains("072"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.LouisaCounty072Property);
                }
                if (establishmentList.Contains("086"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.Madison086Property);
                }
                if (establishmentList.Contains("089"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.Perry089Property);
                }
                if (establishmentList.Contains("069"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.StormLake069Property);
                }
                if (establishmentList.Contains("088"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.Waterloo088Property);
                }
                if (establishmentList.Contains("265"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.GoodLetsVille265Property);
                }
                if (establishmentList.Contains("087"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.CouncilBluffs087Property);
                }
                if (establishmentList.Contains("064"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.Sherman064Property);
                }
            }
            return lotList;
        }
