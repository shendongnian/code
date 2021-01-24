.Aggregations(a => a.Terms(sizesAggName, tt => tt.Field(o => o.Sizes.Suffix("keyword")))
                                .Max(priceAggNameMax, st => st.Field(o => o.SalePrice)))
  .TrackTotalHits()
  .Sort(p => GetSortType(sortType))
  .Index(GetIndexName())
  .From(from)
  .Size(size)
  .Query(q => q.Bool(b => GetQuery(mainCategory, subCategory, subSubcategory, term)))
  .PostFilter( ppf => ppf
  .Terms(tr =>
         {
             var tt = tr.Field(fs => fs.Sizes.Suffix("keyword"));
             return sizesList.Lenght() > 0 ? tt.Terms(selectedSizes) : tt;
         })
  && ppf.Range(r => {
             r = r.Field(f => f.SalePrice);
             if (minPrice > 0) r = r.GreaterThanOrEquals((double)minPrice);
             if (maxPrice > 0) r = r.LessThanOrEquals((double)maxPrice);
             return r;
  })));
