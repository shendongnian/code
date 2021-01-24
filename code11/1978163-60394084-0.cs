                var yourList = (await _ProductDetails.GetAll());
                var takeDistinctCountryIDStateID = (yourList.Where(x => x.IsProductMissing == true &&
                        x.IsProductLogicProcessed == false && !yourList.Where(y=> y.StateId == x.StateId && y.CountryID == x.CountryID && y.Sequece > x.Sequence).Any()).Select(x => new {
                        x.CountryID,
                        x.StateID
                        }).Distinct().Take(20)).ToListAsync());
