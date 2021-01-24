    // Play the dice
    double p = rng.NextDouble();
    double sum = 0.0;
    for (int i = 0; i < 6; i++) {
        sum += loadedDice[i];
        if (sum >= p) {
            Console.Write($"The number is {i + 1}");
            break;
        }
    }
