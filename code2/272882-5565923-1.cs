        public void IncreaseCapacity(int increment)
        {
            var itemsList = (List<T>)Items;
            var total = itemsList.Count + increment;
            if (itemsList.Capacity < total)
            {
                itemsList.Capacity = total;
            }
        }
