     public static bool isStrike = false; //Global Declaration
     ...
     isStrike = true;
     ...
     rollOne = Convert.ToInt32(Console.ReadLine());
     // Do not forget to validate user input: wahat if rollOne = -1234? rollOne = 1234567890? 
     if ((rollOne > 0 && rollOne < array.Length) && 
         ((array[rollOne - 1] != 0) == isStrike)) {
       // rollOne is a valid index (not, say, -1234)
       // array[rollOne - 1] when treated as bool equals to isStrike
     }
     else 
     {
       // either index is wrong or array[rollOne - 1] doesn't correspond to isStrike
     }
