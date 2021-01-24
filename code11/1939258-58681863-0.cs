class Photo
{
    private int width { get; set; }
    private int height { get; set; }
    protected double price;
    public int Width {
        get
        {
            return width;
        }
        set
        {
            width = value;
            updatePrice();
        }
    }
    public int Height {
        get
        {
            return height;
        }
        set
        {
            height = value;
            updatePrice();
        }
    }
    public Photo(int width, int height)
    {
        this.width = width;
        this.height = height;
        updatePrice();
    }
    public virtual double Price
    {
        get
        {
            return price;
        }
    }
    public override string ToString()
    {
        return GetType().Name + 
               " with a width of " + width + 
               " and a height of " + height +
               " with a base price of " + Price.ToString("C2");
    }
    public void updatePrice()
    {
        if (width == 8 && height == 10)
            price = 3.99;
        else if (width == 10 && height == 12)
            price = 5.99;
        else
            price = 9.99;
    }
}
So you don't need to call updatePrice from outside:
    static void Main()
    {
        Photo photo = new Photo(10, 12);
        WriteLine(photo.ToString());
        photo.height = 4;
        WriteLine(photo.ToString());
    }
