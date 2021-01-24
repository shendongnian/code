    using UnityEngine;
    public class CombatDirector : MonoBehaviour
    {
        public Character[] characters = new Character[2];
       void Start()
       {
           foreach (Character character in characters)
           {
                character.MyMethod();
           }
       }
    }
