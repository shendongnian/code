    public void ElementCollisionExample(Elements element1, Elements element2
     {
     Tuple<Elements,Elements> elements = Tuple.Create(element1,element2);
     if(elements.Equals(Tuple.Create(Elements.fire, Elements.earth))
      {
      //do something
      }
     else if(elements.Equals(Tuple.Create(Elements.fire, Elements.water))
      {
      // do something
      }
     // and so on
    }
