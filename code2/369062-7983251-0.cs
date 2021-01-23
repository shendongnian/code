    namespace cardEnum {
        // simple manual enumerator
        class SuitsEnumerator : IEnumerator {
            private int pos = -1;
            private static string[] suits = { "Hearts", "Spades", "Diamonds", "Clubs" };
            public object Current {
                get { return suits[pos]; }
            }
            public bool MoveNext() {
                pos++;
                return (pos < suits.Length);
            }
            public void Reset() {
                pos = -1;
            }
        }
        class Suits : IEnumerable {
            public IEnumerator GetEnumerator() {
                return new SuitsEnumerator();
            }
        }
        class run {
            static void Main() {
                Console.WriteLine("The suits are:");
                var suits = new Suits();
                foreach (var suit in suits) {
                    Console.WriteLine(suit);
                }
                Console.ReadKey();
            }
        }
    }
