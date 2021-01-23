          public Array SomeNewEnglandStates
          {
              get
              {
                  var testArray = Array.CreateInstance(typeof(string), 5);
                  testArray.SetValue("NY", 0);
                  testArray.SetValue("NJ", 1);
                  testArray.SetValue("CT", 2);
                  testArray.SetValue("MA", 3); 
                  testArray.SetValue("ME", 1);
    
                  return testArray;
              }
          }
        }
