    public void ElementCollisionExample(Elements element1, Elements element2)
     {
     Tuple<Elements,Elements> elements = Tuple.Create(element1,element2);
     if(CompareElements(elements, Elements.fire, Elements.earth))
      {
      //do something
      }
     else if(CompareElements(elements, Elements.fire, Elements.water))
      {
      // do something
      }
     // and so on
    }
    private bool CompareElements(Tuple<Elements,Elements> actual, Elements expected1, Elements expected2)
     {
     return actual.Equals(Tuple.Create(expected1, expected2));
     }
