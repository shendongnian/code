        public void Search(string[] searches)
        {
            List<NumberDetails> lstNumberDetails = new List<NumberDetails>();
            foreach (var item in searches)
            {
                var model = lstNumberDetails.FirstOrDefault(x => x.Number == item);
                if (model != null)
                    lstNumberDetails.Add(model);
            }
            gridName.ItemSource = lstNumberDetails;
        }
