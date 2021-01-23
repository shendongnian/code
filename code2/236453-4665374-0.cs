    using Microsoft.Xna.Framework;
    
    namespace wintertermrpg
    {
        public class Camera
        {
            public Matrix viewMatrix;
            private Vector2 m_position;
            private Vector2 m_halfViewSize;
    
            public Camera(Rectangle clientRect)
            {
                m_halfViewSize = new Vector2(clientRect.Width * 0.5f, clientRect.Height * 0.5f);
                UpdateViewMatrix();
            }
    
            public Vector2 Pos
            {
                get
                {
                    return m_position;
                }
    
                set
                {
                    m_position = value;
                    UpdateViewMatrix();
                }
            }
    
            private void UpdateViewMatrix()
            {
                viewMatrix = Matrix.CreateTranslation(m_halfViewSize.X - m_position.X, m_halfViewSize.Y - m_position.Y, 0.0f);
            }
        }
    }
