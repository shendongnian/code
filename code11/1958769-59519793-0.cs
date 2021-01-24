    public class Player
    {
            Enemy enemy;
            public void Initialize()
            {
                enemy = new Enemy();
            }
            public void Update()
            {
                enemy.Update();
                Console.WriteLine(enemy.Rectangle);
            }
        }
        public class Enemy
        {
            public System.Drawing.Rectangle Rectangle;
            public void Update()
            {
                Rectangle = new System.Drawing.Rectangle(5, 10, 10, 10);
            }
    }
