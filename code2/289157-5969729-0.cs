    IEnumerable<int> GetFibonacciNumbers(int n, bool wantall) {
        if(!wantall) {
            return new[] { GetSingleFibonacciNumber(n); }
        }
        else {
            return GetFirstFibonacciNumbers(n);
        }
    }
