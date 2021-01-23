    namespace cardEnum {
        // no explicit SuitsEnumerator required
        class Suits : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return "Hearts";
                yield return "Spades";
                yield return "Diamonds";
                yield return "Clubs";
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
