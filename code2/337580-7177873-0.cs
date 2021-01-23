    public PaymentResult Pay(Amount amount, Order order, IOrderService orderService,
        IPaymentService paymentService) {
      var updatedOrder = orderService.Process(order); // don't alter the original in
                                                      // case you need to roll back
      var result = paymentService.Pay(amount, updatedOrder);
      return result; // this result should include the updated order, so that the system
                     // can determine what to do upon successful payment
    }
