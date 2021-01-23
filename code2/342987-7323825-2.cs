    var cons = (from c in dc.Consignments
                join su in dc.Accounts on c.Subcontractor equals su.Name into sug
                where (sug.FirstOrDefault() == null || sug.FirstOrDefault().Customer == false)
                join p in dc.PODs on c.IntConNo equals p.Consignment into pg
                join d in dc.Depots on c.DeliveryDepot equals d.Letter
                join sl in dc.Accounts on c.Customer equals sl.LegacyID
                join ss in dc.Accounts on sl.InvoiceAccount equals ss.LegacyID                   
                join sub in dc.Accountsubbies on ss.ID equals sub.AccountID into subg
                let firstSubContractor = sug.DefaultIfEmpty().FirstOrDefault()
                select new
                {
                               ID = c.ID,
                               IntConNo = c.IntConNo,
                               LegacyID = c.LegacyID,
                               PODs = pg.DefaultIfEmpty(),
                               TripNumber = c.TripNumber,
                               DropSequence = c.DropSequence,
                               TripDate = c.TripDate,
                               Depot = d.Name,
                               CustomerName = c.Customer,
                               CustomerReference = c.CustomerReference,
                               DeliveryName = c.DeliveryName,
                               DeliveryTown = c.DeliveryTown,
                               DeliveryPostcode = c.DeliveryPostcode,
                               VehicleText = c.VehicleReg + c.Subcontractor,
                               SubbieID = firstSubContractor == null ? "" : firstSubContractor.ID.ToString(),
                               SubbieList = subg.DefaultIfEmpty(),
                               ScanType = ss.PODScanning == null ? 0 : ss.PODScanning
                  });
