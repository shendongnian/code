        /// <summary>
        /// Draw any type of object if the objec type is supported.
        /// Circles, Squares, etc.
        /// </summary>
        /// <param name="objectToDraw"></param>
        public void Draw(object objectToDraw)
        {
            // get the type of object
            string type = objectToDraw.GetType().ToString();
            switch(type)
            {
                case "Circle":
                    
                    // cast the objectToDraw as a Circle
                    Circle circle = objectToDraw as Circle;
                    // if the cast was successful
                    if (circle != null)
                    {
                        // draw the circle
                        circle.Draw();
                    }
                    // required
                    break;
                case "Square":
                    
                    // cast the object as a square
                    Square square = objectToDraw as Square;
                    // if the square exists
                    if (square != null)
                    {
                        // draw the square
                        square.Draw();
                    }
                    // required
                    break;
                default:
                    // raise an error
                    throw new Exception("Object Type Not Supported in Draw method");
            }
        }
