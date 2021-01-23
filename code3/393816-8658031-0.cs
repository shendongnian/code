    interface IFruit
    {
       void Draw();
    }
    
    class Banana : IFruit
    {
       void Draw()
       {
          BananaDrawer drawer = new BananaDrawer();
          drawer.Draw();
       }
    }
