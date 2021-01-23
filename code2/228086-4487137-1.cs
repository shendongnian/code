      IEnumerator<string> it = foo.GetEnumerator();
      for (bool hasNext = it.MoveNext(); hasNext; ) {
         string element = it.Current;
         hasNext = it.MoveNext();
         if (hasNext) { // normal processing
            Console.Out.WriteLine(element);
         } else { // special case processing for last element
            Console.Out.WriteLine("Last but not least, " + element);
         }
      }
