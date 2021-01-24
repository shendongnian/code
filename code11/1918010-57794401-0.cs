    private static void PlayerMove(ref string answer, ref string[] arr)
      {
        for (int i = 0; i <= 8; i++) //make player move
        {
          if (answer == arr[i])
          {
            arr[i] = "X";
          }
        }
      }
