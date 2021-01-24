    private static IEnumerable<int> Primes(int upTo) {
      if (upTo <= 1)
        yield break;
      yield return 2;
      List<int> primes = new List<int>() { };
      for (int number = 3; number <= upTo; number += 2) {
        int max = (int)(Math.Sqrt(number) + 0.5);
        bool isPrime = true;
        foreach (var div in primes)
          if (div > max)
            break;
          else if (number % div == 0) {
            isPrime = false;
            break;
          }
        if (isPrime) {
          primes.Add(number);
          yield return number;
        }
      }
    }
    ...
    txt_result.Text = string.Join(", ", Primes(1000000));
