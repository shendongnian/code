    public bool IsTextFile(string FilePath)
      using (StreamReader reader = new StreamReader(FilePath))
      {
           int Character;
           while ((Character = reader.Read()) != -1)
           {
               if ((Character > 0 && Character < 8) || (Character > 13 && Character < 26))
               {
                        return false; 
               }
           }
      }
      return true;
    }
