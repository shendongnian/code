      foreach (var message in messages)
      {
            string body = Encoding.UTF8.GetString(Convert.FromBase64String(message.Raw));
            Console.WriteLine(body);
      }
