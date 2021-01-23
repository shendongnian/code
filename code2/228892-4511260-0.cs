        void RenderLoop() {
          while (true) {
            SetUpCamera();
            CreateGeometry();
            SwapBuffers();
            Application.DoEvents(); // this lets windows process messages
          }
        }
  
