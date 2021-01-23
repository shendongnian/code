    // abc.h
    #pragma once
    namespace Animals
    {
        public ref class Pets
        {
            Pets(); // forward declaration
            // Pets::Pets is redundant and wrong, because you are inside 
            // the class Pets
        };
    }
    // abc.cpp
    #include "abc.h"
    #ifdef _MANAGED
    #using <system.dll>
    using namespace System;
    using namespace System::IO;
    using namespace System::Collections::Generic;
    using namespace System::Globalization;
    #endif
    namespace Animals
    {
        Pets::Pets() {}  // implementation
        // Now Pets::Pets() is right, because you dont write the class... wrapper again.
    }
