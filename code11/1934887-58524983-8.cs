    using System;
    
    namespace controllertest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Basic Example using inheritance:");
                var test = new Controllable
                {
                    // initialize in controllable does not preset it's values, so all bools are false by default
                    canBeControlled = true,
                    canBeSelected = true,
                    isselected = true
                };
                test.wrapperfunction();
                Console.WriteLine("------------------------------------------------------------------------------------------");
    
                Console.WriteLine("Basic Example partial-hierachy / masking parents:");
                var mask = new presetMaskExample();
                mask.isselected = true;
                mask.wrapperfunction();
                Console.WriteLine("------------------------------------------------------------------------------------------");
    
                Console.WriteLine("Basic Example using a mask as base to build a new controller:");
                var DoesPrint = new PrintStuff();
                DoesPrint.wrapperfunction();
                Console.WriteLine("------------------------------------------------------------------------------------------");
    
                Console.WriteLine("Basic Example registering not derived components:");
                var print = new PrintMe();
                print.allowOthersToPrint = true;
                print.wrapperfunction();
                Console.WriteLine("------------------------------------------------------------------------------------------");
    
            }
        }
    }
