    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication {
        public static class ConsoleApp {
            public static void Main() {
                foreach (var permutation in Permutations("some"))
                    Console.WriteLine(permutation);
                Console.ReadLine();
            }
            public static IEnumerable<String> Permutations(String value) {
                if (value.Length == 1) {
                    yield return value;
                } else {
                    var current = value.Substring(0, 1);
                    foreach (var permutation in Permutations(value.Substring(1)))
                        yield return current + "." + permutation;
                    foreach (var permutation in Permutations(value.Substring(1)))
                        yield return current + permutation;
                }
            }
        }
    }
