                var query = from pl in CurrentDataSource.ProductListing
                                 join pla in CurrentDataSource.ProductListingAttribute
                                     on new {pl.ProductID, pl.WebCategoryID, pl.ParentProductID}
                                     equals new {pla.ProductID, pla.WebCategoryID, pla.ParentProductID}
                                 join att in CurrentDataSource.Attribute
                                     on pla.AttributeID
                                     equals att.AttributeID
                                 join attItem in CurrentDataSource.AttributeItem
                                     on pla.AttributeItemID
                                     equals attItem.AttributeItemID
                            select new
                            {
                                ProductListing = pl,
                                att.AttributeName,
                                attItem.AttributeValue
                            };
                var returnData = query.Where(whereClause).Select(o => o.ProductListing);
