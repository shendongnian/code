    public class MyCam
    {
      float camTurn = 0.0f;
      float camForwardBack = 0.0f;
      // Set the position of the model in world space, and set the rotation.
      Vector3 modelPosition = new Vector3(-200.0f, -175.0f, 10050.0f);
      float modelRotation = 0.0f;
      // Set the position of the camera in world space, for our view matrix.
      Vector3 cameraPosition = new Vector3(camTurn, 0.0f, camForwardBack);
      public MyCam()
      {
         camTurn = 0;
         camForwardBack = 0;
      }
      public void Movement()
      {
        if (Keyboard.GetState().IsKeyDown(Keys.W))
            camForwardBack = camForwardBack + 1;
        else if (Keyboard.GetState().IsKeyDown(Keys.S))
            camForwardBack = camForwardBack - 1;
        else if (Keyboard.GetState().IsKeyDown(Keys.A))
            camTurn = camTurn - 1;
        else if (Keyboard.GetState().IsKeyDown(Keys.D))
            camForwardBack = camForwardBack + 1;
      }
