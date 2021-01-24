                                      var orderIngredients = _repository.Fetch<Ingredient>(
                                        e => e.IngredientType.PlaceId == model.PlaceId
                                          && model.GoodsOrderItems.Any(g => g.OrderItemId == e.Id && g.GoodType == GoodsTypes.Ingredient))
                                        .Select(v => new GoodsOrderIngredient 
                                        {
                                            Id = v.Id,
                                            IngredientId = v.IngredientId,
                                            Quantity = v.Quantity,
                                            CostPerUnit = v.CostPerUnit,
                                            TotalPrice = v.Quantity * v.CostPerUnit
                                        }).ToList();
