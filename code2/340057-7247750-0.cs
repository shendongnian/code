    /// <summary>
    /// Draw the primitive.
    /// </summary>
    /// <param name="world">World Matrix</param>
    /// <param name="view">View Matrix</param>
    /// <param name="projection">Projection Matrix</param>
    /// <param name="color">Color of the primitive</param>
    public void Draw(Matrix world, Matrix view, Matrix projection, Color color)
    {
        _mGraphicsDevice.VertexDeclaration = _mVertexDeclaration;
        _mGraphicsDevice.Vertices[0].SetSource(_mVertexBuffer, 0, VertexPositionNormal.SizeInBytes);
        _mGraphicsDevice.Indices = _mIndexBuffer;
    
        _mBasicEffect.DiffuseColor = color.ToVector3();
        _mBasicEffect.World = _mTransform * world;
        _mBasicEffect.View = view;
        _mBasicEffect.Projection = projection;
    
        int primitiveCount = _mIndex.Count / 3;
    
        _mBasicEffect.Begin();
        foreach (EffectPass pass in _mBasicEffect.CurrentTechnique.Passes)
        {
            pass.Begin();
            _mGraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, _mVertex.Count, 0, primitiveCount);
            pass.End();
        }
        _mBasicEffect.End();
    }
