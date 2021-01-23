        using typedef = System.Int32;
         class MyTypeDef
         {
              typedef ERROR, TRUE=1, FALSE=0;
              public int MyMethod()
              {
                  if(this is an error condition)
                  {
                     ERROR = TRUE;
                  }
                  else
                  {
                      ERROR = FALSE;
                  }
                  return ERROR;
              } // end MyMethod
          } // end MyTypeDef
