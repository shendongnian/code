        public void Search(string[] searches)
        {
            List<NumberDetails> lstNumberDetails = new List<NumberDetails>();
            lstNumberDetails = GetNumbersFromDatabase();
            foreach (var item in searches)
            {
                var modelLst = lstNumberDetails.Where(x => x.Number == item);
                if (modelLst.Any())
                    lstNumberDetails.AddRange(modelLst);
            }
            gridName.ItemSource = lstNumberDetails;
        }
