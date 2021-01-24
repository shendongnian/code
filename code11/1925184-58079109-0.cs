            Dictionary<Order, int> dictionary = new Dictionary<IEntity, int>();
            foreach (Order order in ordersList) {
                if (dictionary.ContainsKey(order)) {
                    dictionary[order] = dictionary[order] + 1;
                }
            }
            vm.ViewOrders = dictionary.Values.ToList();
            foreach (Order order in vm.ViewOrders) {
                order.NumberOfProducts = dictionary[order];
            }
