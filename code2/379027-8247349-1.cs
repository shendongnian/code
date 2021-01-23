    public enum FoodType
    {
        Fruit,
        Veg,
        Meat,
        Candy
    }
    public class Food
    {
        public FoodType Type;
        public string Name { get; set; }
    }
    void RoundRobinSort(List<Food> foods)
    {
        var typeValues = (FoodType[])Enum.GetValues(typeof(FoodType));
        int nextType = 0;
        for (int i = 0; i < foods.Count - 1; i++)
        {
            if (foods[i].Type != typeValues[nextType])
            {
                int itemToSwap = -1;
                int loopGuard = 0;
                while (itemToSwap == -1 && loopGuard <= typeValues.Length)
                {
                    itemToSwap = foods.FindIndex(i, f => f.Type == typeValues[nextType]);
                    if(itemToSwap == -1)
                        nextType = (nextType + 1) % typeValues.Length;
                    loopGuard++;
                }
                if (itemToSwap == -1)
                    throw new Exception("Should never happen, Put a meaningful message here");
                if (itemToSwap != i)
                {
                    var temp = foods[itemToSwap];
                    foods[itemToSwap] = foods[i];
                    foods[i] = temp;
                }
            }
            nextType = (nextType + 1) % typeValues.Length;
        }
    }
