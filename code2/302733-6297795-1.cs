    namespace Frobozz
    {
        namespace Magic
        {
            class Lamp {}
        }
    }
 
    namespace Flathead
    {
        using Frobozz;
        class Bar
        {
            Magic.Lamp myLamp; // Illegal; merely using Frobozz does not bring Magic into scope
        }
    }
