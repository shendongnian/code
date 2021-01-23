    public static Texture2D CreateCircle(GraphicsDevice importedGraphicsDevice, int radius)
        {
            int outerRadius = radius * 2 + 2; // So circle doesn't go out of bounds
            Texture2D texture = new Texture2D(importedGraphicsDevice, outerRadius, outerRadius);
            Color[] data = new Color[outerRadius * outerRadius];
            // Colour the entire texture transparent first.
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Transparent;
            // Work out the minimum step necessary using trigonometry + sine approximation.
            double angleStep = 1f / radius;
            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                // Use the parametric definition of a circle: http://en.wikipedia.org/wiki/Circle#Cartesian_coordinates
                int x = (int)Math.Round(radius + radius * Math.Cos(angle));
                int y = (int)Math.Round(radius + radius * Math.Sin(angle));
                data[y * outerRadius + x + 1] = Color.White;
            }
            //width
            for (int i = 0; i < outerRadius; i++)
            {
                bool foundStart = false;
                //height
                for (int j = 0; j < outerRadius; j++)
                {
                    if (j == outerRadius - 1)
                    {
                        continue;
                    }
                    if (!foundStart && data[i + (j * outerRadius)] == Color.White && data[i + ((j+1) * outerRadius)] == Color.Transparent)
                    {
                        foundStart = true;
                        continue;
                    }
                    if (foundStart)
                    {
                        if (data[i + (j * outerRadius)] != Color.White)
                        {
                            data[i + (j * outerRadius)] = Color.White;
                        }
                        else
                        {
                            //found the end
                            break;
                        }
                    }
                }
            }
            texture.SetData(data);
            return texture;
        }
