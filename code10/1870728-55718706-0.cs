    public class DataModel {
      
      // Values read from text file.
      public string valueOne { get; private set; }
      public string valueTwo { get; private set; }
      public string valueThree { get; private set; }
      
      // Placeholders for GameObjecs created at runtime.
      public GameObject rootObject;
      public GameObject tooltipObject;
      public GameObject panelObject;
      
      public DataModel(string valueOne, string valueTwo, string valueThree){
        this.valueOne = valueOne;
        this.valueTwo = valueTwo;
        this.valueThree = valueThree;
      }
    }
