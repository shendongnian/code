        public void Search(string[] searches)
        {
            List<NumberDetails> lstNumberDetails = new List<NumberDetails>();
            lstNumberDetails = GetNumbersFromDatabase();
            List<NumberDetails> gridItemSource = new List<NumberDetails>();
            foreach (var item in searches)
            {
                var modelLst = lstNumberDetails.Where(x => x.Number == item);
                if (modelLst.Any())
                    gridItemSource.AddRange(modelLst);
            }
            gridName.ItemSource = gridItemSource;
        }
