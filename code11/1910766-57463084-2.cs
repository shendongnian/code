    public class Bot
    {
        private Player player;
        public Rectangle Rectangle { get; set; }
        public Bot(Player player, Size size)
        {
            this.player = player;
            this.Rectangle = new Rectangle() { Size = size };
        }
        public void Follow()
        {
            Point p = player.Rectangle.Location;
            Point bot = Rectangle.Location;
            for (int i = bot.X + 2; i < p.X;)
            {
                bot.X = i;
                break;
            }
            for (int i = bot.X - 2; i > p.X;)
            {
                bot.X = i;
                break;
            }
            for (int i = bot.Y + 2; i < p.Y;)
            {
                bot.Y = i;
                break;
            }
            for (int i = bot.Y - 2; i > p.Y;)
            {
                bot.Y = i;
                break;
            }
            Rectangle = new Rectangle(bot, player.Rectangle.Size);
        }
    }
