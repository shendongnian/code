                    if (q.Count() > 0)
                    {
                        List<StorageMdl> a = db.Storages.Where(x => x.LocationID == lngID && x.IsStored == true && x.Item.isInUse == false)
                                               .Select(x => new StorageMdl
                                               {
                                                   lngID = x.ID,
                                                   strItemID = x.ItemID,
                                                   lngLocationID = x.LocationID,
                                                   itmMdl = new ItemMdl
                                                   {
                                                       strID = x.ID,
                                                       strBarCode = x.Item.Barcode,
                                                       strColor = x.Item.Color,
                                                       bolIsInUse = x.Item.isInUse,
                                                       bolIsActive = x.Item.isActive,
                                                       dteCreateDate = x.Item.CreateDate.Value,
                                                       strDisposalRefNo = x.Item.DisposalRefNo,
                                                       strCreatedBy = x.Item.CreatedBy,
                                                       dteDisposalDate = x.Item.DisposalDate,
                                                       itMdl = new ItemTypeMdl
                                                       {
                                                           lngID = x.Item.ItemType.ID,
                                                           strName = x.Item.ItemType.Name,
                                                           bolHasBarcode = x.Item.ItemType.hasBarcode,
                                                           bolHasManyColors = x.Item.ItemType.hasManyColor,
                                                           strCreatedBy = x.Item.ItemType.CreatedBy,
                                                           dteCreateDate = x.Item.ItemType.CreateDate ?? DateTime.Now,
                                                           bolIsActive = x.Item.ItemType.isActive
                                                       },
                                                       strITName = x.Item.ItemType.Name,
                                                       strManufacturer = x.Item.Manufacturer,
                                                       strDescription = x.Item.Description
                                                   },
                                                   bolIsStored = x.IsStored ?? false,
                                                   strStoredBy = x.StoredBy,
                                                   strApprovedStoreBy = x.ApproveStoreBy,
                                                   dteStoredDate = x.StoreDate,
                                                   dteItemOut = x.ItemOutDate ?? DateTime.Now,
                                                   strItemOutBy = x.ItemOutApproveBy
                                               }).ToList();
                        retVal.Add("exitCode", 1);
                        retVal.Add("list", lststored);
                    }
            
