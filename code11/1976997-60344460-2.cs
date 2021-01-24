    var orderLines = _context.CustomerOrderTab
      .Where(o => o.OrderNo == orderno)
      .Select(o => new OrderDTO {
        OrderNo = o.OrderNo,
        CustomerName = o.CustomerMV.CustomerName,
        ShipmentOrderLines = o.ShipmentOrderLines
          .Select(ob => new ShipmentOrderLinesDTO {
            ShipmentId = ob.ShipmentId,
            OrderNo = ob.OrderNo,
            MyShipment = new ShipmentDTO {
              ShipmentId = ob.Shipment.ShipmentId,
              ...
              ShipmentHandlingUnits = ob.Shipment.ShipmentHandlingUnits
                .Select(shu=> new ShipmentHandlingUnitDTO {
                  ...
                }).ToList()
            }
          }
        }).ToList()
