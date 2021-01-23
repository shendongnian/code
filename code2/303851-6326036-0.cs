    var bstocks = (from p in qry
                    join bstock in bstockRepository.Select() on 
                        p.StockCode equals bstock.StockCode into J1
                    from bstock in J1.DefaultIfEmpty()
                    select new
                    {
                            p.StockCode,
                            p.Description,
                            p.ListPrice,
                            p.Price =  bstock != null && bstock.Price != null ? bstock.Price : p.Price,
                            p.QuantityOnHand ,
                            p.Cube,
                            p.ShippingFormat,
                            p.Weight,
                            p.NextShipment,
                            p.NextShipment2,
                            p.NextShipmentQuantity,
                            p.NextShipment2Quantity,
                            Bstock = p.Bstock
                        });
