cs
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BlockMonglerFixed1
{
    public class Rectangle
    {
        /// <summary>
        /// Width of the rectangle
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Height of the rectangle
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Length of the rectangle
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// Position of the rectangle
        /// </summary>
        public Vector3 Position { get; set; }
        /// <summary>
        /// Rotation vector3 of the rectangle. X = pitch. Y = yaw. Z = roll
        /// </summary>
        public Vector3 Rotation { get; set; }
        /// <summary>
        /// GraphicsDevice used to draw the rectangle
        /// </summary>
        public GraphicsDevice GraphicsDevice { get; set; }
        /// <summary>
        /// BasicEffect used to to draw the rectangle
        /// </summary>
        public BasicEffect Effect { get; set; }
        /// <summary>
        /// Color of the rectangle. Not used if a texture is being used
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// Texture of the rectangle. Not used if a color is being used.
        /// </summary>
        public Texture3D Texture { get; set; }
        /// <summary>
        /// Determines if the rectangle should move based on its rotation
        /// </summary>
        public bool MoveBasedOnRotation { get; set; }
        int _vertexLength;
        VertexBuffer _buffer;
        RasterizerState _rasterizerState;
        /// <summary>
        /// Cube constructor. Generates a new rectangle
        /// </summary>
        /// <param name="width">Width of rectangle</param>
        /// <param name="height">Height of rectangle</param>
        /// <param name="length">Length of rectangle</param>
        /// <param name="position">Position of the rectangle></param>
        /// <param name="rotation">Rotation of the rectangle. This value rotates the rectangle</param>
        /// <param name="graphicsDevice">GraphicsDevice used to draw the rectangle</param>
        /// <param name="effect">Effect of rectangle</param>
        /// <param name="color">Color of rectangle</param>
        /// <param name="moveBasedOnRotation">Determines if the rectangle should move based on its rotation</param>
        public Rectangle(int width, int height, int length, Vector3 position,
            Vector3 rotation, GraphicsDevice graphicsDevice, BasicEffect effect, Color color, bool moveBasedOnRotation)
        {
            //Dimensions of the rectangle
            Width = width;
            Height = height;
            Length = length * 2;
            //Position setup
            Position = position;
            //Rotation setup
            Rotation = rotation;
            MoveBasedOnRotation = moveBasedOnRotation;
            //Effect setup
            Effect = effect;
            //Color setup
            Color = color;
            //Graphics device setup.
            GraphicsDevice = graphicsDevice;
            //Cube setup
            VertexPositionColor[] vertexPositionColors =
            {
                //Face 1
                new VertexPositionColor(new Vector3(-Width, Height, 0), Color),
                new VertexPositionColor(new Vector3(-Width, -Height, 0), Color),
                new VertexPositionColor(new Vector3(Width, -Height, 0), Color),
                new VertexPositionColor(new Vector3(-Width, Height, 0), Color),
                new VertexPositionColor(new Vector3(Width, Height, 0), Color),
                new VertexPositionColor(new Vector3(Width, -Height, 0), Color),
                //Face 2
                new VertexPositionColor(new Vector3(-Width, Height, -Length), Color),
                new VertexPositionColor(new Vector3(-Width, -Height, -Length), Color),
                new VertexPositionColor(new Vector3(Width, -Height, -Length), Color),
                new VertexPositionColor(new Vector3(-Width, Height, -Length), Color),
                new VertexPositionColor(new Vector3(Width, Height, -Length), Color),
                new VertexPositionColor(new Vector3(Width, -Height, -Length), Color),
                //Side 1
                new VertexPositionColor(new Vector3(-Width, Height, -Length), Color),
                new VertexPositionColor(new Vector3(-Width, -Height, -Length), Color),
                new VertexPositionColor(new Vector3(-Width, -Height, 0), Color),
                new VertexPositionColor(new Vector3(-Width, Height, 0), Color),
                new VertexPositionColor(new Vector3(-Width, -Height, 0), Color),
                new VertexPositionColor(new Vector3(-Width, Height, -Length), Color),
                //Side 2
                new VertexPositionColor(new Vector3(Width, Height, 0), Color),
                new VertexPositionColor(new Vector3(Width, -Height, 0), Color),
                new VertexPositionColor(new Vector3(Width, -Height, -Length), Color),
                new VertexPositionColor(new Vector3(Width, Height, -Length), Color),
                new VertexPositionColor(new Vector3(Width, -Height, -Length), Color),
                new VertexPositionColor(new Vector3(Width, Height, 0), Color),
                //Bottom
                new VertexPositionColor(new Vector3(-Width, -Height, -Length), Color),
                new VertexPositionColor(new Vector3(-Width, -Height, 0), Color),
                new VertexPositionColor(new Vector3(Width, -Height, 0), Color),
                new VertexPositionColor(new Vector3(-Width, -Height, -Length), Color),
                new VertexPositionColor(new Vector3(Width, -Height, -Length), Color),
                new VertexPositionColor(new Vector3(Width, -Height, 0), Color),
                //Top
                new VertexPositionColor(new Vector3(-Width, Height, -Length), Color),
                new VertexPositionColor(new Vector3(-Width, Height, 0), Color),
                new VertexPositionColor(new Vector3(Width, Height, 0), Color),
                new VertexPositionColor(new Vector3(-Width, Height, -Length), Color),
                new VertexPositionColor(new Vector3(Width, Height, -Length), Color),
                new VertexPositionColor(new Vector3(Width, Height, 0), Color),
            };
            //Length setup
            _vertexLength = vertexPositionColors.Length;
            //Buffer setup
            _buffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), _vertexLength,
                BufferUsage.WriteOnly);
            //Set data of the buffer to the vertexList
            _buffer.SetData(vertexPositionColors);
            
            _rasterizerState = new RasterizerState {CullMode = CullMode.None};
            GraphicsDevice.RasterizerState = _rasterizerState;
        }
        public Rectangle(int width, int height, int length, Matrix worldMatrix, Matrix projectionMatrix,
            Matrix viewMatrix,
            GraphicsDevice graphicsDevice, BasicEffect effect, Texture3D texture)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sees if the rectangle collides with another object
        /// </summary>
        /// <param name="otherRectangle">Rectangle to detect collision with</param>
        public bool IsColliding(Rectangle otherRectangle)
        {
            //Get the minimum values of our position
            float minX = Position.X - Width;
            float minY = Position.Y - Height;
            float minZ = Position.Z - Length / 2f;
            //Get the maximum values of our position
            float maxX = Position.X + Width;
            float maxY = Position.Y + Height;
            float maxZ = Position.Z + Length / 2f;
            //Get the minimum values of the other rectangle's position
            float otherMinX = otherRectangle.Position.X - otherRectangle.Width;
            float otherMinY = otherRectangle.Position.Y - otherRectangle.Height;
            float otherMinZ = otherRectangle.Position.Z - otherRectangle.Length / 2f;
            //Get the maximum values of the other rectangle's positions
            float otherMaxX = otherRectangle.Position.X + otherRectangle.Width;
            float otherMaxY = otherRectangle.Position.Y + otherRectangle.Height;
            float otherMaxZ = otherRectangle.Position.Z + otherRectangle.Length / 2f;
            //We can calculate if one rectangle is in another by seeing if one of our sides is inside another rectangle
            return minX <= otherMaxX && maxX >= otherMinX &&
                   minY <= otherMaxY && maxY >= otherMinY &&
                   minZ <= otherMaxZ && maxZ >= otherMinZ;
            
        }
        /// <summary>
        /// Draws the triangle to the screen
        /// </summary>
        public void Draw()
        {
            //Hold the current position
            Vector3 tempPosition = Position;
            //Create a new matrix with the position and rotation
            Matrix effectWorldMatrix = Matrix.CreateWorld(Vector3.Zero, Vector3.Forward, Vector3.Up) *
                                       Matrix.CreateTranslation(-new Vector3(0, 0, -Length / 2f)) *
                                       Matrix.CreateRotationX(Rotation.X) *
                                       Matrix.CreateRotationY(Rotation.Y) *
                                       Matrix.CreateRotationZ(Rotation.Z) *
                                       Matrix.CreateTranslation(Position);
            //If MoveBasedOnRotation is true, set the translation of our new matrix to the previous translation
            //if (!MoveBasedOnRotation) effectWorldMatrix.Translation = tempPosition;
            //Set the effect to our respective matrices;
            Effect.World = effectWorldMatrix;
            Effect.View = Camera.ViewMatrix;
            Effect.Projection = Camera.ProjectionMatrix;
            //Apply our vertex buffer to the graphics device
            GraphicsDevice.SetVertexBuffer(_buffer);
            foreach (EffectPass pass in Effect.CurrentTechnique.Passes)
            {
                //Apply the pass
                pass.Apply();
                //Use the graphics device to draw the triangle
                GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, _vertexLength);
            }
        }
    }
}
