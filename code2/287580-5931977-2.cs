	// Update each block
	personHit = false;
	contactPoints.Clear();
	for(int i = 0; i < blocks.Count; i++)
	{
		// Animate this block falling
		blocks[i].Position += new Vector2(0.0f, BlockFallSpeed);
		blocks[i].Rotation += BlockRotateSpeed;
		// Build the block's transform
		Matrix blockTransform =
			Matrix.CreateTranslation(new Vector3(-blockOrigin, 0.0f)) *
			// Matrix.CreateScale(block.Scale) *  would go here
			Matrix.CreateRotationZ(blocks[i].Rotation) *
			Matrix.CreateTranslation(new Vector3(blocks[i].Position, 0.0f));
		// Calculate the bounding rectangle of this block in world space
		Rectangle blockRectangle = CalculateBoundingRectangle(
					new Rectangle(0, 0, blockTexture.Width, blockTexture.Height),
					blockTransform);
		// The per-pixel check is expensive, so check the bounding rectangles
		// first to prevent testing pixels when collisions are impossible.
		if(personRectangle.Intersects(blockRectangle))
		{
			contactPoints.AddRange(IntersectPixels(personTransform, personTexture.Width,
								personTexture.Height, personTextureData,
								blockTransform, blockTexture.Width,
								blockTexture.Height, blockTextureData));
			// Check collision with person
			if(contactPoints.Count != 0)
			{
				personHit = true;
			}
		}
		// Remove this block if it have fallen off the screen
		if(blocks[i].Position.Y >
			Window.ClientBounds.Height + blockOrigin.Length())
		{
			blocks.RemoveAt(i);
			// When removing a block, the next block will have the same index
			// as the current block. Decrement i to prevent skipping a block.
			i--;
		}
	}
	base.Update(gameTime);
