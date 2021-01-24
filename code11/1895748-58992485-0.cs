      foreach(var user in result) {
          Console.WriteLine(string.Concat((string)user.Item1.Item1.GetType().GetProperty("Name").GetValue(user.Item1.Item1,null), " (user id = ", user.Item1.Item2,")"));
             foreach (var inviter in user.Item2) {
                 Console.WriteLine(string.Concat("  ", (string)inviter.Item1.GetType().GetProperty("Name").GetValue(inviter.Item1, null), " (inviter id = ", inviter.Item3,")"));
             }
      }
      Console.ReadKey();
