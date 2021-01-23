    using System;
    using System.Collections.Generic;
    using Codebase;
    
    namespace Cmd
    {
        static class Program
        {
            static void Main(string[] args)
            {
                var tune = new LinkedList(); //Using custom code instead of the built-in LinkedList<T>
                tune.AddFirst("do"); // do
                tune.AddLast("so"); // do - so
                tune.AddAfter(tune.First, "re"); // do - re- so
                tune.AddAfter(tune.First.Next, "mi"); // do - re - mi- so
                tune.AddBefore(tune.Last, "fa"); // do - re - mi - fa- so
                tune.RemoveFirst(); // re - mi - fa - so
                tune.RemoveLast(); // re - mi - fa
                Node miNode = tune.Find("mi"); //Using custom code instead of the built in LinkedListNode
                tune.Remove(miNode); // re - fa
                tune.AddFirst(miNode); // mi- re - fa
     }
    }
