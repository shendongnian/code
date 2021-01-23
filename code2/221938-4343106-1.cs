      const int minTotalDiff = 200;    // parameter used in new color acceptance criteria
      const int okSingleDiff = 100;    // id.
    
      int prevR, prevG, prevB;  // R, G and B components of the previously issued color.
      Random RandGen = null;
    
      public string GetNewColor()
      {
          int newR, newG, newB;
    
          if (RandGen == null)
          {
              RandGen = new Random();
              prevR = prevG = prevB = 0;
          }
    
          bool found = false;
          while (!found)
          {
              newR = RandGen.Next(255);
              newG = RandGen.Next(255);
              newB = RandGen.Next(255);
    
              int diffR = Math.Abs(prevR - newR);
              int diffG = Math.Abs(prevG - newG);
              int diffB = Math.Abs(prevB - newB);
      
              // we only take the new color if...
              //   Collectively the color components are changed by a certain
              //   minimum
              //   or if at least one individual colors is changed by "a lot".
              if (diffR + diffG + diffB >= minTotalDiff
                  || diffR >= okSingleDiff
                  || diffR >= okSingleDiff
                  || diffR >= okSingleDiff
              )
                found = true;
            }
        
           prevR = newR;
           prevG = newG;
           prevB = newB;
    
          return String.Format("#{0:X2}{0:X2}{0:X2}", prevR, prevG, prevB);
      }
