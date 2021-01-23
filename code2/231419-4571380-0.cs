     public void parseRules (State state, IEnumerable<Element> elements)
     {
          foreach (Element element in elements)
          {
               if (element.Name.Equals("strategy"))
               {
                    parseNewStrategy(state, element);
               }
               else if (element.Name.Equals("gate"))
               {
                    parseNewGate(state,element);
               }
          }
     }
