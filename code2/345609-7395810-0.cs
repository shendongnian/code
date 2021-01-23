    m_device.BeginScene();
    m_device.Clear(ClearFlags.Target, Color.Black, 1.0f, 0);
    m_sprite.Begin(SpriteFlags.SortTexture | SpriteFlags.AlphaBlend);
    // The "1.0f" is the z-order of texture1.  This places it at the very back.
    m_sprite.Draw(m_texture1, Vector3.Empty, new Vector3(0, 0, 1.0f), 
                 Color.White.ToArgb());
    // The text1 is placed at z-order 0.8f, in order to place it in front of texture1
    Microsoft.DirectX.Matrix t = Microsoft.DirectX.Matrix.Identity;
    t.Translate(new Vector3(0, 0, 0.8f));
    m_sprite.Transform = t;
    m_d3dFont.DrawText(m_sprite, m_text1, 200, 200, color1);
    m_sprite.Transform = Microsoft.DirectX.Matrix.Identity;
    // The "0.6f" is the z-order of texture2.  This places it at the very back.
    m_sprite.Draw(m_texture2, Vector3.Empty, new Vector3(220, 220, 0.6f), 
                  Color.White.ToArgb());
    // The text2 is placed at z-order 0.4f, in order to place it in front of texture2
    t = Microsoft.DirectX.Matrix.Identity;
    t.Translate(new Vector3(0, 0, 0.4f));
    m_sprite.Transform = t;
    m_d3dFont.DrawText(m_sprite, m_text2, 240, 240, color2);
    m_sprite.Transform = Microsoft.DirectX.Matrix.Identity;
    m_sprite.End();
    m_device.EndScene();
    m_device.Present();
