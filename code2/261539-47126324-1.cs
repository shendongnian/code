    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    
    namespace Console_vs_Debug {
     class Program {
      class Trial {
       public string name;
       public Action console;
       public Action debug;
       public List < float > consoleMeasuredTimes = new List < float > ();
       public List < float > debugMeasuredTimes = new List < float > ();
      }
    
      static Stopwatch sw = new Stopwatch();
      private static int repeatLoop = 1000;
      private static int iterations = 2;
      private static int dummy = 0;
    
      static void Main(string[] args) {
       if (args.Length == 2) {
        repeatLoop = int.Parse(args[0]);
        iterations = int.Parse(args[1]);
       }
    
       // do some dummy work
       for (int i = 0; i < 100; i++) {
        Console.WriteLine("-");
        Debug.WriteLine("-");
       }
    
       for (int i = 0; i < iterations; i++) {
        foreach(Trial trial in trials) {
         Thread.Sleep(50);
         sw.Restart();
         for (int r = 0; r < repeatLoop; r++)
          trial.console();
         sw.Stop();
         trial.consoleMeasuredTimes.Add(sw.ElapsedMilliseconds);
         Thread.Sleep(1);
         sw.Restart();
         for (int r = 0; r < repeatLoop; r++)
          trial.debug();
         sw.Stop();
         trial.debugMeasuredTimes.Add(sw.ElapsedMilliseconds);
    
        }
       }
       Console.WriteLine("---\r\n");
       foreach(Trial trial in trials) {
        var consoleAverage = trial.consoleMeasuredTimes.Average();
        var debugAverage = trial.debugMeasuredTimes.Average();
        Console.WriteLine(trial.name);
        Console.WriteLine($ "    console: {consoleAverage,11:F4}");
        Console.WriteLine($ "      debug: {debugAverage,11:F4}");
        Console.WriteLine($ "{consoleAverage / debugAverage,32:F2} (console/debug)");
        Console.WriteLine();
       }
    
       Console.WriteLine("all measurements are in milliseconds");
       Console.WriteLine("anykey");
       Console.ReadKey();
      }
    
      private static List < Trial > trials = new List < Trial > {
       new Trial {
        name = "constant",
         console = delegate {
          Console.WriteLine("A static and constant string");
         },
         debug = delegate {
          Debug.WriteLine("A static and constant string");
         }
       },
       new Trial {
        name = "dynamic",
         console = delegate {
          Console.WriteLine("A dynamically built string (number " + dummy++ + ")");
         },
         debug = delegate {
          Debug.WriteLine("A dynamically built string (number " + dummy++ + ")");
         }
       },
       new Trial {
        name = "interpolated",
         console = delegate {
          Console.WriteLine($ "An interpolated string (number {dummy++,6})");
         },
         debug = delegate {
          Debug.WriteLine($ "An interpolated string (number {dummy++,6})");
         }
       }
      };
     }
    }
