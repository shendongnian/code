       MainImage.ManipulationDelta += PhoneApplicationPage_ManipulationDelta;
            }...
            void PhoneApplicationPage_ManipulationDelta(object sender, ManipulationDeltaEventArgs e) {
              // Scale the rectangle.
              // Move the rectangle.
              var transform = (CompositeTransform)MainImage.RenderTransform;
              if (transform.ScaleX != 1 || transform.ScaleY != 1) {
                transform.TranslateX += e.DeltaManipulation.Translation.X;
                transform.TranslateY += e.DeltaManipulation.Translation.Y;
              }
            }
