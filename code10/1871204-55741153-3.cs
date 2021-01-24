    public class ExampleMonoBehaviour : MonoBehaviour
    {
        // Replace `TheClassName` by the name of the class above, containing the `Start` function
        // Drag & drop in the inspector the gameObject holding the previous class
        public TheClassName CharactersManager;
    
    
        // I use `Start` for the sake of the example
        private void Start()
        {
            // According to your code, `_Character` is defined **inside** the other class
            // so you have to use this syntax
            // You can get rid of `TheClassName.` if you declare `_Character` outside of it
            TheClassName._Character john = CharactersManager.GetCharacter( 100 );
        }
    }
