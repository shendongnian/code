    public class PlayerInitClass : Microsoft.EntityFrameworkCore.DbContext
    {
    public PlayerInitClass()
    {
        this.context = context;
    }
    public PlayerInitClass context { get; set; }
