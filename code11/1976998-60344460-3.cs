    public static class CustomerOrderTabExtensions {
      public static CustomerOrderDto ToDto(this CustomerOrderTab cot) {
        return new CustomerOrderDto {
          OrderNo = cot.OrderNo,
          ...
          OrderLines = cot.CustomerOrderLines
            .Select(col=>col.ToDto())
            .ToList()
        }
      }
    }
