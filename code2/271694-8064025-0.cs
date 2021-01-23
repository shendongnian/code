     count += 1;
                    string counter = count.ToString();
                    int w = GraphicsDevice.PresentationParameters.BackBufferWidth;
                    int h = GraphicsDevice.PresentationParameters.BackBufferHeight;
                    //force a frame to be drawn (otherwise back buffer is empty) 
                    Draw(new GameTime());
                    //pull the picture from the buffer 
                    int[] backBuffer = new int[w * h];
                    GraphicsDevice.GetBackBufferData(backBuffer);
                    //copy into a texture 
                    Texture2D texture = new Texture2D(GraphicsDevice, w, h, false, GraphicsDevice.PresentationParameters.BackBufferFormat);
                    texture.SetData(backBuffer);
                   
                        //save to disk 
                        Stream stream = File.OpenWrite(counter + ".jpg");
                        texture.SaveAsJpeg(stream, w, h);
                        stream.Dispose();
                        
                        texture.Dispose();
  
                }
            
        }
