     class RemoteFileDP
     {
          ....
          public static implicit operator RemoteFileDP(string locationDictionary)
          {
               //return a new and appropiately initialized RemoteFileDP object.
               //you could mix this solution with Anna's the following way:
               return new RemoteFileDP(locationDictionary);
          }
     }
