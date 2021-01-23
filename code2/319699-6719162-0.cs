    class SimpleRenderer : Component, IRenderComponent
    {
        public void Draw()
        {
            sb.Draw(texture, Self.Get<IPositionComponent>().Position, Color.White);
        }
    }
