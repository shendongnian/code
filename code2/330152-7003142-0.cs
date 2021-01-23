                List<PaymentDetailsItemType> items = paymentDetails.PaymentDetailsItem;
            foreach (ShoppingCartItem item in cart.ShoppingCartItems)
            {
                items.Add(new PaymentDetailsItemType
                              {
                                  Name = item.Book.Title,
                                  Quantity = item.Quantity,
                                  Number = item.BookId.ToString(),
                                  Amount =
                                      new BasicAmountType
                                          {currencyID = CurrencyCodeType.USD, 
                                           value = (item.Book.Price).To2Places()}
                              });
            }
            if (cartTotals.Discount > 0)
            {
                items.Add(new PaymentDetailsItemType
                              {
                                  Name = "Promo Code Discount",
                                  Quantity = 1,
                                  Number = "PromoCode",
                                  Amount =
                                      new BasicAmountType
                                          {
                                              currencyID = CurrencyCodeType.USD,
                                              value = (cartTotals.Discount*-1).To2Places()
                                          }
                              });
            }
