    namespace Frobozz
    {
        namespace Magic
        {
            class Lamp {}
        }
   
        class Foo
        {
            Magic.Lamp myLamp; // Legal; Magic means Frobozz.Magic when inside Frobozz
        }
    }
