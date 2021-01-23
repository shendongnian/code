    foreach (MyComposedModel otherObject in some list)
    {
     //ThisObject.Reset();                  // clears all properties
       thisObject = new MyComposedModel();  // create a new instance instead
      ....
      TheListOfModel.Add(thisObject);
    }
