            var props = objInput.GetType().GetProperties();
            var types = props.Where(x => x.Name.StartsWith("Type"))
                .Select(x => x.GetValue(objInput)).ToList();
            var breaks = props.Where(x => x.Name.StartsWith("Break"))
                .Select(x => x.GetValue(objInput)).ToList();
            var basics = props.Where(x => x.Name.StartsWith("Basic"))
                .Select(x => x.GetValue(objInput)).ToList();
            var rates = props.Where(x => x.Name.StartsWith("Rate"))
                .Select(x => x.GetValue(objInput)).ToList();
            List<RateDetail> lstDetails = new List<RateDetail>();
            for (int i = 0; i < types.Count; i++)
            {
                lstDetails.Add(new RateDetail
                {
                    RateType = types[i].ToString(),
                    Break = Convert.ToDecimal(breaks[i]),
                    Basic = Convert.ToDecimal(basics[i]),
                    Rate = Convert.ToDecimal(rates[i])
                });
            }
