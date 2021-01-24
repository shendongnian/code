    List<StorageMdl> lst = db.Storages.Where(x => x.LocationID == lngID && x.IsStored == true && x.Item.isInUse == false)
                      .Select(x => new StorageMdl
                        {
                            lngID = x.ID,
                            strItemID = x.ItemID,
                            lngLocationID = x.LocationID,
                            itmMdl = new ItemMdl
                            {
                                strID = x.ID
                                strBarCode = x.Item.Barcode,
                                strColor = x.Item.Color,
                                bolIsInUse = x.Item.isInUse,
                                bolIsActive = x.Item.isActive,
                                dteCreateDate = x.Item.CreateDate.Value,
                                strDisposalRefNo = x.Item.DisposalRefNo,
                                strCreatedBy = x.Item.CreatedBy,
                                dteDisposalDate = x.Item.DisposalDate!=null ? x.Item.DisposalDate.Value : DateTime.MinValue,
                                itMdl = new ItemTypeMdl
                                {
                                    lngID = x.Item.ItemType.ID,
                                    strName = x.Item.ItemType.Name,
                                    bolHasBarcode = x.Item.ItemType.hasBarcode,
                                    bolHasManyColors = x.Item.ItemType.hasManyColor,
                                    strCreatedBy = x.Item.ItemType.CreatedBy,
                                    dteCreateDate = x.Item.ItemType.CreateDate!=null ? x.Item.ItemType.CreateDate.Value : DateTime.MinValue,
                                    bolIsActive = x.Item.ItemType.isActive
                                },
                                strITName = x.Item.ItemType.Name,
                                strManufacturer = x.Item.Manufacturer,
                                strDescription = x.Item.Description
                            },
                            bolIsStored = x.IsStored!=null ? x.IsStored.Value : false,
                            strStoredBy = x.StoredBy,
                            strApprovedStoreBy = x.ApproveStoreBy,
                            dteStoredDate = x.StoreDate,
                            dteItemOut = x.ItemOutDate!=null ? x.ItemOutDate.Value : DateTime.MinValue,
                            strItemOutBy = x.ItemOutApproveBy
                        }).ToList();
