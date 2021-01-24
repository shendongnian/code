csharp
class GameState {
   List<BallStructure> balls;
}
class BallStructure {
   Vector3 position;
   Color color;
}
Now you can use a serializer to serialize this.
csharp
public class Serializer {
    const string SerializationVersion = "1";
    public string SerializeToString(GameState gameState) {
        // some magic that turns the thing into a string, maybe a JSON
    }
}
Now your savegame file holds this:
json
{
   "_serializationVersion": "1"
   balls : [
      {
         "position" : "1,2,5",
         "color" : "#289328"
      },
      {
         "position" : "1,2,5",
         "color" : "#289328"
      }
   ]
}
Now you can write some deserializer that can read this back into a `GameState` object.
csharp
class Deserializer {
     public GameState Deserialize(string input) {
         // some json parsing magic and you get the game state back
     }
}
Now lets go with your example and you have meanwhile had 3 iterations, so your serializer would now look like this:
csharp
public class Serializer {
    const string SerializationVersion = "3";
    public string SerializeToString(GameState gameState) {
        // some magic that turns the thing into a string, maybe a JSON
    }
}
Nothing changes for your game code. It still works on a `GameState` object. The `Deserializer` now needs to account for some versions though:
csharp
class Deserializer {
     public GameState Deserialize(string input) {
        var jsonObject = JSONParser.Parse(input);
        var version = jsonObject.Get("_serializationVersion");
        if (version  == "1") {
            return DerserializeFromVersion1(jsonObject);
        }
        if (version  == "2") {
            return DerserializeFromVersion2(jsonObject);
        }
        if (version  == "3") {
            return DerserializeFromVersion3(jsonObject);
        }
     }
     private GameState DeserializeFromVersion1(JSONObject jsonObject) {
     }
     private GameState DeserializeFromVersion2(JSONObject jsonObject) {
     }
     private GameState DeserializeFromVersion3(JSONObject jsonObject) {
     }
}
Again, the details are hidden inside the deserializer. Both your game code and the serializer use always the latest and greatest version. The deserializer handles migrating loaded games into this latest version. Of course if you have more than just this simple example, you will probably amp this up a bit (e.g. have one deserializer per version and aggregate these in the deserializer class that your game code works with), e.g.
csharp
class Deserializer {
    private List<Deserializer> supportedDeserializers = new List<..>(); // get some instances here e.g. with dependency injection
     public GameState Deserialize(string input) {
        var jsonObject = // ... same code as above
        var version = // ... same code as above;
        for(var deserializer in supportedDeserializers) {
            if (deserializer.SupportsVersion(version)) {
                return deserializer.Deserialize(jsonObject);
            }
        }
     }
}
interface IDeserializer {
    bool CanDeserializeVersion(string version);
    GameState Deserialize(JsonObject object);
}
class V1Deserializer : IDeserializer {
   // ...
}
class V2Deserializer : IDeserializer {
   // ...
}
class V3Deserializer : IDeserializer {
   // ...
}
This way your game code can just call the main deserializer and be happy and you don't need to juggle around all kinds of versions of your domain objects. 
Of course there may always be situation when a migration is simply not possible, e.g if you decide to remove the balls from your game altogether and replace them with spaceships. Also while being in the pre-release stages it might be a good idea to tell your testers that savegames of the alpha and beta version may not be compatible with the final version or at least announce breaking changes well ahead of time.
