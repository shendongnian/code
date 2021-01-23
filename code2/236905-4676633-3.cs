    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    
    namespace WindowsGame
    {
        public class Ball
        {
            const int DIAMETER = 40;
            const float RADIUS = DIAMETER * 0.5f;
            const float MASS = 0.25f;
            const int PIXELS = DIAMETER * DIAMETER;
    
            static readonly uint WHITE = Color.White.PackedValue;
            static readonly uint BLACK = new Color(0, 0, 0, 0).PackedValue;
    
            Texture2D m_texture;
            Vector2 m_position;
            Vector2 m_velocity;
    
            public Ball(GraphicsDevice graphicsDevice)
            {
                m_texture = new Texture2D(graphicsDevice, DIAMETER, DIAMETER);
    
                uint[] data = new uint[PIXELS];
    
                for (int i = 0; i < DIAMETER; i++)
                {
                    float iPosition = i - RADIUS;
    
                    for (int j = 0; j < DIAMETER; j++)
                    {
                        data[i * DIAMETER + j] = new Vector2(iPosition, j - RADIUS).Length() <= RADIUS ? WHITE : BLACK;
                    }
                }
    
                m_texture.SetData<uint>(data);
            }
    
            public float Radius
            {
                get
                {
                    return RADIUS;
                }
            }
    
            public Vector2 Position
            {
                get
                {
                    return m_position;
                }
            }
    
            public Vector2 Velocity
            {
                get
                {
                    return m_velocity;
                }
    
                set
                {
                    m_velocity = value;
                }
            }
    
            public void ApplyImpulse(Vector2 impulse)
            {
                Vector2 acceleration = impulse / MASS;
                m_velocity += acceleration;
            }
    
            public void Update(float dt)
            {
                m_position += m_velocity;   // Euler integration - innaccurate and unstable but it will do for this simulation
            }
    
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(m_texture, DrawRectangle, Color.White);
            }
    
            private Rectangle DrawRectangle
            {
                get
                {
                    int x = (int)Math.Round(m_position.X - RADIUS);
                    int y = (int)Math.Round(m_position.Y - RADIUS);
    
                    return new Rectangle(x, y, DIAMETER, DIAMETER);
                }
            }
        }
    
        public class Boundary
        {
            private Vector2 m_point1;
            private Vector2 m_point2;
            private Vector2 m_normal;
            private float m_distance;
            
            public Boundary(Vector2 point1, Vector2 point2)
            {
                m_point1 = point1;
                m_point2 = point2;
    
                m_normal = new Vector2();
                m_normal.X = point2.Y - point1.Y;
                m_normal.Y = point1.X - point2.X;
    
                m_distance = point2.X * point1.Y - point1.X * point2.Y;
    
                float invLength = 1.0f / m_normal.Length();
    
                m_normal *= invLength;
                m_distance *= invLength;
            }
    
            public Vector2 Normal
            {
                get
                {
                    return m_normal;
                }
            }
    
            public void PerformCollision(Ball ball)
            {
                float distanceToBallCenter = DistanceToPoint(ball.Position);
    
                if (distanceToBallCenter <= ball.Radius)
                {
                    ResolveCollision(ball);
                }
            }
    
            public void ResolveCollision(Ball ball)
            {
                ball.Velocity = Vector2.Reflect(ball.Velocity, m_normal);
            }
    
            private float DistanceToPoint(Vector2 point)
            {
                return 
                    m_normal.X * point.X + 
                    m_normal.Y * point.Y + 
                    m_distance;
            }
        }
    
        public class World
        {
            Boundary m_left;
            Boundary m_right;
            Boundary m_top;
            Boundary m_bottom;
    
            public World(float left, float right, float top, float bottom)
            {
                m_top = new Boundary(new Vector2(right, top), new Vector2(left, top));
                m_right = new Boundary(new Vector2(right, bottom), new Vector2(right, top));
                m_bottom = new Boundary(new Vector2(left, bottom), new Vector2(right, bottom));
                m_left = new Boundary(new Vector2(left, top), new Vector2(left, bottom));
            }
    
            public void PerformCollision(Ball ball)
            {
                m_top.PerformCollision(ball);
                m_right.PerformCollision(ball);
                m_bottom.PerformCollision(ball);
                m_left.PerformCollision(ball);
            }
        }
    
        public class Game1 : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
            Matrix viewMatrix;
            Matrix inverseViewMatrix;
            Ball ball;
            World world;
    
            public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
                IsMouseVisible = true;
            }
    
            protected override void Initialize()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
    
                ball = new Ball(GraphicsDevice);
    
                float right = Window.ClientBounds.Width * 0.5f;
                float left = -right;
                float bottom = Window.ClientBounds.Height * 0.5f;
                float top = -bottom;
    
                world = new World(left, right, top, bottom);
    
                viewMatrix = Matrix.CreateTranslation(Window.ClientBounds.Width * 0.5f, Window.ClientBounds.Height * 0.5f, 0.0f);
                inverseViewMatrix = Matrix.Invert(viewMatrix);
    
                base.Initialize();
            }
    
            private void ProcessUserInput()
            {
                MouseState mouseState = Mouse.GetState();
    
                Vector2 mousePositionClient = new Vector2((float)mouseState.X, (float)mouseState.Y);
                Vector2 mousePositionWorld = Vector2.Transform(mousePositionClient, inverseViewMatrix);
    
                if (mousePositionWorld != ball.Position)
                {
                    Vector2 impulse = mousePositionWorld - ball.Position;
                    impulse *= 1.0f / impulse.LengthSquared();
                    ball.ApplyImpulse(-impulse);
                }
            }
    
            protected override void Update(GameTime gameTime)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();
    
                float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
    
                ProcessUserInput();
    
                ball.Update(dt);
                world.PerformCollision(ball);
    
                base.Update(gameTime);
            }
    
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
    
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, viewMatrix);
    
                ball.Draw(spriteBatch);
    
                spriteBatch.End();
    
                base.Draw(gameTime);
            }
        }
    }
