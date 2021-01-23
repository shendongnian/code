     protected override void Update(GameTime gameTime)
      {
        var keyboard = Keyboard.GetState();
        if(keyboard.IsKeyDown(Keys.C))
        {
          if(freeCam.Enabled)
          {
            freeCam.Enabled = false;
            freeCam.Visible = false;
            staticCam.Enabled = true;
            staticCam.Visible= true;
          }
          else
          {
            freeCam.Enabled = true;
            freeCam.Visible = true;
            staticCam.Enabled = false;
            staticCam.Visible= false;
          }         
        }
        base.Update(gameTime);
      }
