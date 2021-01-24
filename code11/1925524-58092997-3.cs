    public class Character { }
    public class Warrior : Character { }
    public class Mague : Character { }
    public class Priest : Character { }
    public class Game : MonoBehaviour
    {
      private Type[] CharacterTypes
        = { typeof(Warrior), typeof(Mague), typeof(Priest) };
      List<Character> characters = new List<Character>();
      void Start()
      {
        var random = new Random();
        for ( int i = 0; i < 10; i++ )
        {
          var characterType = CharacterTypes[random.Next(CharacterTypes.Length)];
          characters.Add((Character)Activator.CreateInstance(characterType));
        }
      }
    }
