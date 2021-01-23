    using System;
    using System.Collections.Generic;
    namespace TrySortedList {
      class Program {
        class Header {
          public int XPos;
          public string Name;
        }
        static void Main(string[] args) {
          SortedList<int, List<Header>> sortedHeaders = new SortedList<int,List<Header>>();
          add(sortedHeaders, 1, "Header_1");
          add(sortedHeaders, 1, "Header_2");
          add(sortedHeaders, 2, "Header_3");
          foreach (var headersKvp in sortedHeaders) {
            foreach (Header header in headersKvp.Value) {
              Console.WriteLine(header.XPos + ": " + header.Name);
            }
          }
        }
        private static void add(SortedList<int, List<Header>> sortedHeaders, int xPos, string name) {
          List<Header> headers;
          if (!sortedHeaders.TryGetValue(xPos, out headers)){
            headers = new List<Header>();
            sortedHeaders[xPos] = headers;
          }
          headers.Add(new Header { XPos = xPos, Name = name });
        }
      }
    }
    Output:
    1: Header_1
    1: Header_2
    2: Header_3
