    // Open the file for reading
    using (StreamReader reader = new StreamReader((Stream)file1.PostedFile.InputStream))
    {
      // as long as we have content to read, continue reading
      while (reader.Peek() > 0)
      {
        // split the line by the equal sign. so, e.g. if:
        //   ReadLine() = .RES B7=121
        // then
        //   parts[0] = ".RES b7";
        //   parts[1] = "121";
        String[] parts = reader.ReadLine().split(new[]{ '=' });
        
        // Make the values a bit more bullet-proof (in cases where the line may
        // have not split correctly, or we won't have any content, we default
        // to a String.Empty)
        // We also Substring the left hand value to "skip past" the ".RES" portion.
        // Normally I would hard-code the 5 value, but I used ".RES ".Length to
        // outline what we're actually cutting out.
        String leftHand = parts.Length > 0 ? parts[0].Substring(".RES ".Length) : String.Empty;
        String rightHand = parts.Length > 1 ? parts[1] : String.Empty;
        
        // output will now contain the line you're looking for. Use it as you wish
        String output = String.Format("<label>{0}</label><input type=\"text\" value=\"{0}\" />", leftHand, rightHand);
      }
      
      // Don't forget to close the stream when you're done.
      reader.Close();
    }
