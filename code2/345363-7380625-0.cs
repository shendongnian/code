	Model table;
	Model racket;
	
	Vector3 modelPosition = new Vector3(0,100,150);
	Vector3 modelPosition_table = new Vector3(0,40,0);
	
	// Set the position of the camera in world space, for our view matrix.
	Vector3 cameraPosition_racket = new Vector3(0.0f, 1000.0f, 10.0f);
	Vector3 cameraPosition_table = new Vector3(0.0f, 150.0f, 250.0f);
	
	Vector3 cameraPosition = cameraPosition_racket;
	Vector3 cameraTarget  = new Vector3(0.0f, 0.0f, 0.0f);
	
	Matrix mView = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
	Matrix mProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), aspectRatio, 1.0f, 10000.0f);
	
	
	
	void Draw_Racket()
	{
	    // Copy any parent transforms.
	    Matrix[] transforms_racket = new Matrix[racket.Bones.Count];
	    racket.CopyAbsoluteBoneTransformsTo(transforms_racket);
	
	    // Draw the model. A model can have multiple meshes, so loop.
	    foreach (ModelMesh mesh in racket.Meshes)
	    {
	        // This is where the mesh orientation is set, as well 
	        // as our camera and projection.
	        foreach (BasicEffect effect in mesh.Effects)
	        {
	            effect.EnableDefaultLighting();
	            effect.World = transforms_racket[mesh.ParentBone.Index] *     Matrix.CreateRotationY(modelRotation) * Matrix.CreateTranslation(modelPosition);
	            effect.View = mView;
	            effect.Projection = mProjection;
	        }
	        // Draw the mesh, using the effects set above.
	        mesh.Draw();
	    }
	}
	
	void Draw_Table()
	{
	
	    // Copy any parent transforms.
	    Matrix[] transforms_table = new Matrix[table.Bones.Count];
	    table.CopyAbsoluteBoneTransformsTo(transforms_table);
	
	    // Draw the model. A model can have multiple meshes, so loop.
	    foreach (ModelMesh mesh in table.Meshes)
	    {
	        // This is where the mesh orientation is set, as well 
	        // as our camera and projection.
	        foreach (BasicEffect effect in mesh.Effects)
	        {
	            effect.EnableDefaultLighting();
	            effect.World = transforms_table[mesh.ParentBone.Index] * Matrix.CreateTranslation(modelPosition_table);
	            effect.View = mView;
	            effect.Projection = mProjection;
	        }
	        // Draw the mesh, using the effects set above.
	        mesh.Draw();
	    }
	
	}
	
	protected override void Draw(GameTime gameTime)
	{
	    graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
	
	    Draw_Table();
	    Draw_Racket();
	
	    base.Draw(gameTime);
	}
