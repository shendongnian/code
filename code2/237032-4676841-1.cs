    public void RenderShape(GraphicsDevice device, Effect effect)
    {
        BuildShape();
    
        foreach (EffectPass pass in effect.CurrentTechnique.Passes)
        {
            effect.Parameters["xTexture"].SetValue(topTexture);
            pass.Apply();
            device.DrawUserPrimitives(PrimitiveType.TriangleList, shapeVertices[2], 0, 2);
    
            effect.Parameters["xTexture"].SetValue(bottomTexture);
            pass.Apply();
            device.DrawUserPrimitives(PrimitiveType.TriangleList, shapeVertices[3], 0, 2);
    
            effect.Parameters["xTexture"].SetValue(frontTexture);
            pass.Apply();
            device.DrawUserPrimitives(PrimitiveType.TriangleList, shapeVertices[0], 0, 2);
    
            effect.Parameters["xTexture"].SetValue(backTexture);
            pass.Apply();
            device.DrawUserPrimitives(PrimitiveType.TriangleList, shapeVertices[1], 0, 2);
    
            effect.Parameters["xTexture"].SetValue(leftTexture);
            pass.Apply();
            device.DrawUserPrimitives(PrimitiveType.TriangleList, shapeVertices[4], 0, 2);
    
            effect.Parameters["xTexture"].SetValue(rightTexture);
            pass.Apply();
            device.DrawUserPrimitives(PrimitiveType.TriangleList, shapeVertices[5], 0, 2);
        }
    }
