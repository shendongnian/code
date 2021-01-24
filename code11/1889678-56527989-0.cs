      List<System.Drawing.Color?> list = new List<System.Drawing.Color?>() {
        System.Drawing.Color.Red,
        System.Drawing.Color.Black,
        null,                        // <- should be excluded
        System.Drawing.Color.Blue,
      };
      foreach (System.Drawing.Color col in list.OfType<System.Drawing.Color>())
        Console.WriteLine(col);
