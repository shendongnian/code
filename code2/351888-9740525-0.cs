    public class DishBlogg(Blogg blogg, Dish dish)
    {
        this.LastBlogg = blogg;
        this.LastDish = dish;
    }
    public Blogg LastBlogg { get; private set; }
    public Dish LastDish { get; private set; }
