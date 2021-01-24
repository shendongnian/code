    public List<string> ParseLot()
        {
            var lotList = new List<string>();
            var establishmentList = GetEstablishmentCode();
            foreach (var lot in GetBarcodeList())
            {
                if (lot.Contains("038"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.LoganSport038Property);
                }
                if (lot.Contains("072"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.LouisaCounty072Property);
                }
                if (lot.Contains("086"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.Madison086Property);
                }
                if (lot.Contains("089"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.Perry089Property);
                }
                if (lot.Contains("069"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.StormLake069Property);
                }
                if (lot.Contains("088"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.Waterloo088Property);
                }
                if (lot.Contains("265"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.GoodLetsVille265Property);
                }
                if (lot.Contains("087"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.CouncilBluffs087Property);
                }
                if (lot.Contains("064"))
                {
                    lotList.Add(lot.Substring(28, 6) + _lotEstablishment.Sherman064Property);
                }
            }
            return lotList;
        }
